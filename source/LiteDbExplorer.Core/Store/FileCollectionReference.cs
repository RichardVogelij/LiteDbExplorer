﻿using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace LiteDbExplorer.Core
{
    public sealed class FileCollectionReference : CollectionReference
    {
        public FileCollectionReference(string name, DatabaseReference database) : base(name, database)
        {
        }

        protected override IEnumerable<DocumentReference> GetAllItem(ILiteCollection<BsonDocument> liteCollection)
        {
            return LiteCollection.FindAll().Select(bsonDocument => new FileDocumentReference(bsonDocument, this));
        }

        public override void RemoveDocument(DocumentReference document)
        {
            Database.LiteDatabase.FileStorage.Delete(document.LiteDocument["_id"]);
            Items.Remove(document);
        }

        public DocumentReference AddFile(string id, string path)
        {
            throw new NotImplementedException();
            //var file = Database.LiteDatabase.FileStorage.Upload(id, path);
            //var newDoc = new DocumentReference(file..AsDocument, this);
            //Items.Add(newDoc);
            //return newDoc;
        }

        public void SaveFile(DocumentReference document, string path)
        {
            var file = GetFileObject(document);
            file.SaveAs(path);
        }

        public LiteFileInfo<object> GetFileObject(DocumentReference document)
        {
            throw new NotImplementedException();
            //return Database.LiteDatabase.FileStorage.FindById(document.LiteDocument["_id"]);
        }
    }
}