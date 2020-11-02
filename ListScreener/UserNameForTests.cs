using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    public static class UserNameForTests
    {
        public const string LOGIN = "admin@admin.com";
        public const string PASSWORD = "Admin123!";
        public const string ACTUAL_MESSAGE = "Let's start email list verification!";

        public const string LOGIN_USER = "celladecummo-1094@yopmail.com";
        public const string PASSWORD_USER = "Test123!";

    }

    public static class MailsForSingleMail
    {
        public const string MAIL_VALID = "ribalka.vladik@gmail.com";
        public const string MAIL_INVALID = "123@gmail.com";
        public const string MAIL_THREAT = "bajeqasse-3049@yopmail.com";
        public const string MAIL_DESCRETIONARY = "annalibera.dm@icloud.com";


        public const string VALID_EXPECTED_ANSWER = "Valid";
        public const string INVALID_EXPECTED_ANSWER = "Invalid";
        public const string THREAT_EXPECTED_ANSWER = "Threat";
        public const string DESCRETIONARY_EXPECTED_ANSWER = "Discretionary";

        public const string ERROR_MESSAGE_FOR_ASSERT = "Error, Text not found";

    }

    public static class MailsForBulkVerification
    {
        public const string ONE_MAIL_TXT = "D:\\ListScreener\\One mail for auto-tests.txt";
        public const string CHECK_STATISTIC_MAIL = "D:\\ListScreener\\Check Statistic.txt";
        public const string EXPECTED_STATUS_FILE = "Completed";
        public const string EXPECTED_PROGRESS_FILE = "100 %";
    }


    public static class DataForCreateUser
    {
        public const string EMAIL = "celladecummo-1094@yopmail.com";
        public const string USER_NAME = "1elladecummo";
        public const string FIRST_NAME = "1elladecummo";
        public const string LAST_NAME = "1elladecummo";
        public const string PASSWORD = "Test123!";
        public const string PASSWORD_EDITED = "Admin123!";
    }


    public static class DataForChangePassword
    {
        public const string CURRENT_PASSWORD = "Admin123!";
        public const string NEW_PASSWORD = "Test123!";
    }


    public static class DataStatistic
    {
        public const string VERIFIED_MAILS = "4";
        public const string VALID = "1";
        public const string INVALID = "2";
        public const string BULK_VERIFICATION = "3";
        public const string VERIFICATION_LISTS = "1";
        public const string SINGLE_VERIFICATION = "1";
        public const string TOTAL = "3";
        public const string ACCEPT_ALL = "1";
        public const string ROLE = "1";
        public const string SPAM = "2";
        public const string DISPOSABLE = "1";
        public const string ERROR_STATISTICS = "Fields don't match";
    }
}
