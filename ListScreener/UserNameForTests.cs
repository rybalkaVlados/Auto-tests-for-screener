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
        public const string EXPECTED_STATUS_FILE = "Completed";
        public const string EXPECTED_PROGRESS_FILE = "100 %";
    }
}
