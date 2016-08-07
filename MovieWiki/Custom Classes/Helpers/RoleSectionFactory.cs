using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWiki.Custom_Classes
{
    public class RoleSectionFactory
    {
        public RoleSection GetInstance(string role)
        {
            switch (role)
            {
                case "ActorSection": return new ActorSection();
                case "ProducerSection": return new ProducerSection();
                case "DirectorSection": return new DirectorSection();
                default: throw new Exception("Error creating RoleSection");
            }
        }

        public RoleSection GetInstance(string role, string description)
        {
            var roleSection = GetInstance(role);
            roleSection.Description = description;
            return roleSection;
        }
    }
}