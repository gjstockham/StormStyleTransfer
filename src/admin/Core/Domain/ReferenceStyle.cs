using System;

namespace StormStyleTransfer.Admin.Core.Domain
{
    public class ReferenceStyle
    {
        public Guid Id {get; set;}
        
        public string ModelName {get; set;}

        public string ImageName {get; set;}

        public string Artist {get; set;}

        public string Title {get; set;}

        public string MimeType {get; set;}

        public ProcessingStatus Status {get; set;}
    }

    public enum ProcessingStatus
    {
        Uploaded,
        InProcess,
        Completed
    }
}