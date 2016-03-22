﻿/***********************************************************************
Copyright 2016 Stefan Hausotte

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*************************************************************************/

using System.Text;

namespace PeNet.Structures
{
    /// <summary>
    ///     The IMAGE_DATA_DIRECTORY struct represents the data directory,
    /// </summary>
    public class IMAGE_DATA_DIRECTORY
    {
        private readonly byte[] _buff;
        private readonly uint _offset;

        /// <summary>
        ///     Create a new IMAGE_DATA_DIRECTORY object.
        /// </summary>
        /// <param name="buff">PE binary as byte array.</param>
        /// <param name="offset">Raw offset to the data directory in the binary.</param>
        public IMAGE_DATA_DIRECTORY(byte[] buff, uint offset)
        {
            _buff = buff;
            _offset = offset;
        }

        /// <summary>
        ///     RVA of the table.
        /// </summary>
        public uint VirtualAddress
        {
            get { return Utility.BytesToUInt32(_buff, _offset); }
            set { Utility.SetUInt32(value, _offset, _buff); }
        }

        /// <summary>
        ///     Table size in bytes.
        /// </summary>
        public uint Size
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x4); }
            set { Utility.SetUInt32(value, _offset + 0x4, _buff); }
        }

        /// <summary>
        ///     Convert all object properties to strings.
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder("IMAGE_DATA_DIRECTORY\n");
            sb.Append(Utility.PropertiesToString(this, "{0,-10}:\t{1,10:X}\n"));

            return sb.ToString();
        }
    }
}