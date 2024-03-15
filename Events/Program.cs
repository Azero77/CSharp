using System;


namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new() { Title = "Memories" };
            VideoEncoder videoEncoder = new();


            MailService Email = new();
            videoEncoder.VideoEncoded += Email.VideoEncoded;
            videoEncoder.Encode(video);
        }
    }

    class Video
    {
        public string Title { get; set; }
    }

    class VideoEncoder
    {
        //for writing an event
        ///1- write a delegate => the event handler refrence in subscribers
        ///2- write an event to that delegate => which is type of Event that contains all subscribers listining to the event
        ///3- raise the event => the convention is using "On" before the event name as the name of the function that will raise the event and notify all subscripers and invoke there event handlers

        public delegate void VideoEncodedEventHandler(object source, EventArgs e);
        public event VideoEncodedEventHandler VideoEncoded; 
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding...");
            Thread.Sleep(3000);
            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if(VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty);
            }
        }

    }

    class MailService
    {
        public void VideoEncoded(object source , EventArgs e)
        {
            Console.WriteLine("Sending Mail Message....");
            Thread.Sleep(2000);
            
        }
    }
}