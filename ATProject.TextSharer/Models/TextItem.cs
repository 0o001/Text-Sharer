using System;
using System.Security.Permissions;
using MongoDB.Bson.Serialization.Attributes;

namespace TextSharer.Models
{
    public class TextItem : Base
    {
        public string Text { get; protected set; }
        [BsonElement]
        public string Code => Id.Substring(18);
        public TextItem(string text)
        {
            this.Text = text;
        }
    }
}
