using PostSharp.Aspects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.Core.Aspects.PostSharp.AuthAspects
{
    [Serializable]
   public class SecuredOperation: OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if(System.Threading.Thread.CurrentPrincipal.Identity==null)
            {
                throw new SecurityException("Login Required !");
            }
            string[] roles = Roles.Split(',');
            bool IsAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if(System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    IsAuthorized = true;
                }
            }
            if(IsAuthorized==false)
            {
                throw new SecurityException("You Are Not Authorized To Do This Transaction !");
            }
        }
    }
}
