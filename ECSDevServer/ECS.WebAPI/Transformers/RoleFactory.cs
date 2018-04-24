﻿using System;
using ECS.Constants.Security;
using ECS.WebAPI.Transformers.Interfaces;

namespace ECS.WebAPI.Transformers
{
    public class RoleFactory : IFactory
    {
        public Object Create(string roleType)
        {
            roleType = roleType.ToLower();
            switch (roleType)
            {
                case "public":
                    return ClaimValues.Scholar;
                case "private":
                    return ClaimValues.Admin;
                default:
                    throw new UnauthorizedAccessException("RoleType input invalid");
            }
        }
    }
}