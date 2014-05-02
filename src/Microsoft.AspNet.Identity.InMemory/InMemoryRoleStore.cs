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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.InMemory
{
    public class InMemoryRoleStore<TRole> : IQueryableRoleStore<TRole> where TRole : IdentityRole

    {
        private readonly Dictionary<string, TRole> _roles = new Dictionary<string, TRole>();

        public Task CreateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            _roles[role.Id] = role;
            return Task.FromResult(0);
        }

        public Task DeleteAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (role == null || !_roles.ContainsKey(role.Id))
            {
                throw new InvalidOperationException("Unknown role");
            }
            _roles.Remove(role.Id);
            return Task.FromResult(0);
        }

        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = new CancellationToken())
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            _roles[role.Id] = role;
            return Task.FromResult(0);
        }

        public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_roles.ContainsKey(roleId))
            {
                return Task.FromResult(_roles[roleId]);
            }
            return Task.FromResult<TRole>(null);
        }

        public Task<TRole> FindByNameAsync(string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return
                Task.FromResult(
                    Roles.SingleOrDefault(r => String.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase)));
        }

        public void Dispose()
        {
        }

        public IQueryable<TRole> Roles
        {
            get { return _roles.Values.AsQueryable(); }
        }
    }
}