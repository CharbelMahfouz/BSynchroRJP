﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BSynchroRJP.DataAccessLayer
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }

    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
