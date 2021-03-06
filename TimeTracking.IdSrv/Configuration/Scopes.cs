﻿using IdentityServer4.Core.Models;
using System.Collections.Generic;

namespace TimeTracking.IdSrv.configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.EmailAlwaysInclude,
                StandardScopes.OfflineAccess,
                StandardScopes.RolesAlwaysInclude,

                new Scope {
                    Name = "timeTrackingAPI",
                    Description = "API for the Time Tracking resources",
                    Type = ScopeType.Resource,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256()) //todo: created secret
                    },
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role"),
                        new ScopeClaim(General.Constants.Idsrv.ScopeTimeTrackingRecords)
                    }
                },

                new Scope
                {
                    Name = "api1",
                    DisplayName = "API 1",
                    Description = "API 1 features and data",
                    Type = ScopeType.Resource,

                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                },
                new Scope
                {
                    Name = "api2",
                    DisplayName = "API 2",
                    Description = "API 2 features and data, which are better than API 1",
                    Type = ScopeType.Resource
                }
            };
        }
    }
}