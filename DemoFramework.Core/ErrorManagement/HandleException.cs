using DemoFramework.Core.Constants.Messages;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.Core.ErrorManagement
{
  public  class HandleException
    {
        public static void ExceptionThrow (Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (SqlException)
            {
                throw new BaseHandleException(ExceptionMessages.SqlExceptionMessage);
            }
            catch (DbUpdateException)
            {
                throw new BaseHandleException(ExceptionMessages.DbUpdateExceptionMessage);
            }
            catch (IndexOutOfRangeException)
            {
                throw new BaseHandleException(ExceptionMessages.IndexOutOfRangeExceptionMessage);
            }
            catch(NullReferenceException)
            {
                throw new BaseHandleException(ExceptionMessages.IndexOutOfRangeExceptionMessage);
            }
            catch (AccessViolationException)
            {
                throw new BaseHandleException(ExceptionMessages.AccessViolationExceptionMessage);
            }
            catch (InvalidOperationException)
            {
                throw new BaseHandleException(ExceptionMessages.InvalidOperationExceptionMessage);
            }
            catch (ArgumentException)
            {
                throw new BaseHandleException(ExceptionMessages.ArgumentExceptionMessage);
            }
            catch (ExternalException)
            {
                throw new BaseHandleException(ExceptionMessages.ExternalExceptionMessage);
            }
           
            catch (Exception)
            {
                throw new BaseHandleException(ExceptionMessages.ExceptionMessage);
            }
           
        }
    }
}
