// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING
// WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF
// TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR
// NON-INFRINGEMENT.
// See the Apache 2 License for the specific language governing
// permissions and limitations under the License.

namespace Microsoft.AspNet.Identity
{
    /// <summary>
    ///     Represents a message
    /// </summary>
    public class IdentityMessage
    {
        /// <summary>
        ///     Destination, i.e. To email, or SMS phone number
        /// </summary>
        public virtual string Destination { get; set; }

        /// <summary>
        ///     Subject
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        ///     Message contents
        /// </summary>
        public virtual string Body { get; set; }
    }
}