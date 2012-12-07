using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MVC4FormsAuth.Types;
using MVC4FormsAuth.Managers;

namespace MVC4FormsAuth.Web.Providers
{
    public class MyMembershipProvider : MembershipProvider
    {
        #region Not Used

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
            /*string[] parts = providerUserKey.ToString().Split(new char[] { '_' });
            if (parts.Length == 2)
            {
                string username = parts[0];
                long userId;
                if (Int64.TryParse(parts[1], out userId))
                {
                    User user = UserClient.Load(username, userId);
                    if (user.UserDataUserId > 0)
                    {
                        return new MembershipUser("APMembershipProvider", user.UserDataLoginName, UserManager.User.UserDataUserId, UserManager.User.UserDataLoginName, null, null, true, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                    }
                }
            }

            return null;*/
        }

        #endregion

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        ///<param name="username">Username</param>
        ///<param name="password">Password</param>
        /// <returns>bool</returns>
        public override bool ValidateUser(string username, string password)
        {
            // Check if this is a valid user.
            User user = UserManager.AuthenticateUser(username, password);
            if (user != null)
            {
                // Store the user temporarily in the context for this request.
                HttpContext.Current.Items.Add("User", user);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves the user details for a particular user.
        /// </summary>
        ///<param name="username">User to retrieve user details for</param>
        ///<param name="userIsOnline"></param>
        /// <returns>MembershipUser</returns>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (UserManager.User != null)
            {
                return new MembershipUser("MyMembershipProvider", username, UserManager.User.Id, UserManager.User.Username, null, null, true, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            }
            else
            {
                return null;
            }
        }
    }
}