using System;

namespace DailyLog {
 public class MessageEntity
    {
        public string Message { get; }
        public DateTime DateTime { get; }
        public string[] Tags { get; }

        public MessageEntity(string message, string[] tags = null)
        {
            this.Message = message;
            this.DateTime = DateTime.Now;
            this.Tags = tags ?? new string[] { };
        }

        public override string ToString()
        {
            return $"{this.DateTime.ToString("dd/mm/yyyy hh:MM")} - {this.Message} - {String.Join(",", this.Tags)}";
        }

    }
}