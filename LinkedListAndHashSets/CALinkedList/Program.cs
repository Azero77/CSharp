using System.Collections.Generic;

namespace CALinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YTVideo vid1 = new YTVideo() { Duration = new TimeSpan(5,10,3) , Title = "Generics" , Id = "YT1"};
            YTVideo vid2 = new YTVideo() { Duration = new TimeSpan(1, 10, 3), Title = "Variables", Id = "YT2" };
            YTVideo vid3 = new YTVideo() { Duration = new TimeSpan(3, 20, 3), Title = "Lists", Id = "YT3" };
            YTVideo vid4 = new YTVideo() { Duration = new TimeSpan(4, 20, 3), Title = "IOStream", Id = "YT4" };
            YTVideo vid5 = new YTVideo() { Duration = new TimeSpan(2, 10, 3), Title = "Test", Id = "YT5" };
            YTVideo[] videos = {vid1 , vid2 , vid3 , vid4 , vid5 };

            LinkListNode < YTVideo > List = new LinkListNode< YTVideo >();
            for (int i = 0 , l = videos.Length; i < l; i++)
            {
                var tmp = List.Next;
                List.Next = new LinkListNode<YTVideo> { Value = videos[i] };
                List.Next.Next = tmp;
            }
            var iterator = List;
            while(iterator != null)
            {
                if(iterator.Value != null)
                {
                    Console.WriteLine(iterator.Value);
                }
                iterator = iterator.Next;
            }
            Console.WriteLine("###################3");
            //we don't need to suffer that much we can use LinkedList<T> built-in IEnumerable
            var NewList = new LinkedList<YTVideo>();
            var nod1 = NewList.AddFirst(vid1);
            NewList.AddAfter(nod1 , vid2);
            var nod5 = NewList.AddLast(vid5);
            NewList.AddBefore(nod5 , vid3);

            foreach(var item in NewList)Console.WriteLine(item);


        }
    }


    class YTVideo
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            return $"{Title} => {Duration}\n\t[https://www.youtube.com/watch?v=BKYiNKfmuGk&list+Id={Id}]";
        }
    }


    class LinkListNode<T>
    {
        public T? Value;
        public LinkListNode<T>? Next;
    }
}
