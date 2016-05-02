using System;
using System.Configuration;
using IADP.MoHra.Model;

namespace IADP.MoHra.Helpers
{
    public static class DatabaseHelper
    {
        private static string _userId = "";
        private static string _password = "";

        /// <summary>
        /// Проверяет подключение. Сохраняет логин/пароль, если подключиться удалось.
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection(string userId, string password, ref string errorMessage)
        {
            var result = false;
            var oldUserId = _userId;
            var oldPassword = _password;
            try
            {
                _StoreConnection(userId, password);

                using (var db = new DB())
                {
                    db.Database.Connection.Open();

                    var connectionState = db.Database.Connection.State;
                    if (connectionState != System.Data.ConnectionState.Open)
                        throw new Exception($"Соединение не открыто. Текущий статус: {connectionState}.");
                    db.Database.Connection.Close();
                }

                result = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                _StoreConnection(oldUserId, oldPassword);
            }
            return result;
        }

        private static void _StoreConnection(string userId, string password)
        {
            _userId = userId;
            _password = password;
        }

        public static string FixConnectionString(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            var replacableString = "provider connection string=\"";
            var additionString = $"user id={_userId};password={_password};";
            var insertIndex = connectionString.IndexOf(replacableString) + replacableString.Length;
            return connectionString.Insert(insertIndex, additionString);
        }
    }
}