using System;

using Vanara.PInvoke;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;

namespace ZeldaWindWakerTrainer
{
    internal class ProcessWrapper
    {
        private readonly string _processName;
        private string _processLocation;
        private Kernel32.SafeHPROCESS _process;
        private long _baseAddress = 0x0;

        public ProcessWrapper(string processName)
        {
            _processName = processName;
        }

        public bool OpenProcess()
        {
            Process[] processes = Process.GetProcessesByName(_processName);
            
            if (processes.Length != 1)
            {
                return false;
            }

            // Required rights : 0x0010 | 0x0400 | 0x0020 | 0x0008
            _process = Kernel32.OpenProcess(ACCESS_MASK.GENERIC_ALL, true, (uint)processes[0].Id);

            if (processes[0].MainModule == null) throw new Exception("Process main module is null.");
            
            _processLocation = processes[0].MainModule.FileName;

            return true;
        }

        public void SetBaseAddress(long baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public bool OverwriteMemoryProtection(long address, int size)
        {
            return Kernel32.VirtualProtectEx(_process, (IntPtr)(_baseAddress + address), size, Kernel32.MEM_PROTECTION.PAGE_READWRITE, out Kernel32.MEM_PROTECTION oldProtection);
        }

        public byte[] ReadMemory(long address, int size, MemoryType memoryType)
        {
            IntPtr memoryReadPtr = Marshal.AllocHGlobal(size);

            Kernel32.ReadProcessMemory(_process, (IntPtr)(_baseAddress + address), memoryReadPtr, size, out SizeT readSize);

            byte[] memoryBuffer = new byte[readSize];
            Marshal.Copy(memoryReadPtr, memoryBuffer, 0, readSize);
            Marshal.FreeHGlobal(memoryReadPtr);

            return ProcessMemoryType(memoryBuffer, memoryType);
        }

        public byte[] ReadMemory(Offset offset)
        {
            return ReadMemory(offset.Address, offset.Size, offset.MemoryType);
        }

        public bool WriteMemory(long address, byte[] data, MemoryType memoryType)
        {
            data = ProcessMemoryType(data, memoryType);

            IntPtr dataPtr = Marshal.AllocHGlobal(data.Length);

            Marshal.Copy(data, 0, dataPtr, data.Length);

            bool writeResult = Kernel32.WriteProcessMemory(_process, (IntPtr)(_baseAddress + address), dataPtr, data.Length, out SizeT wroteCount);

            Marshal.FreeHGlobal(dataPtr);

            return writeResult;
        }

        public bool WriteMemory(Offset offset, byte[] data)
        {
            return WriteMemory(offset.Address, data, offset.MemoryType);
        }

        public string GetProcessLocation()
        {
            return _processLocation;
        }

        private static byte[] ProcessMemoryType(byte[] data, MemoryType memoryType)
        {
            if (memoryType == MemoryType.BigEndian && data.Length > 1)
            {
                data = data.Reverse().ToArray();
            }
            return data;
        }
    }
}
