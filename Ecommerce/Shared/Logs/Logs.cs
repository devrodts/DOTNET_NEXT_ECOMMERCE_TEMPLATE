
using System;
using Serilog; 

namespace Ecommerce.Shared.Logs
{
    public static class LogException
    {

        public static void LogAppException(Exception exception)
        {

            LogToFile(exception.Message, exception.StackTrace);    
            LogToConsole(exception.Message, exception.StackTrace);  
            LogToDebug(exception.Message, exception.StackTrace);   
        }

        public static void LogToFile(string message, string? stackTrace) =>
            Log.Error("{@Message} - StackTrace: {@StackTrace}", message, stackTrace); 

        public static void LogToConsole(string message, string? stackTrace) =>
             Log.Error("{@Message} - StackTrace: {@StackTrace}", message, stackTrace); 

        public static void LogToDebug(string message, string? stackTrace) =>
            Log.Error("{@Message} - StackTrace: {@StackTrace}", message, stackTrace); 
   
        public static void LogToFile(string message) => Log.Information(message);

        public static void LogToConsole(string message) => Log.Information(message); 

        public static void LogToDebug(string message) => Log.Information(message);
    }
}