using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.Documentor.Domain.Repository;
using HeaviSoft.Documentor.Domain.DataEntity;
using HeaviSoft.FrameworkBase.Utility;

namespace HeaviSoft.Documentor.Presentation.Login.Implements
{
    public class InitializeModule : ILoginModule
    {
        public bool Login(ExtendedApplicationBase app)
        {
            var user = new User() { Name = "test", Password = EncryptHelper.DES3Encrypt("test") };
            using(var unitOfWork = new UnitOfWork())
            {
                if (unitOfWork.UserRepository.GetUserByName(user.Name) == null)
                {
                    unitOfWork.UserRepository.Add(user);
                }
            }

            return true;
        }

        public void LoginFailed(ExtendedApplicationBase app, object message)
        {
            
        }

        public void LoginSuccessed(ExtendedApplicationBase app, object message)
        {
            
        }
    }
}
