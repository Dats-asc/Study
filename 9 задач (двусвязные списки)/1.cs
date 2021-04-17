using System;
using System.Collections.Generic;

namespace Двусвязный_список_9_задач
{
	class BookList
	{
		public LinkedList<string> Books { get; set; }

		public BookList()
		{
			Books = new LinkedList<string>();
		}

		public BookList(string bookName)
		{
			Books = new LinkedList<string>();

			Books.AddFirst(new LinkedListNode<string>(bookName));
		}

		public BookList(LinkedList<string> books)
		{
			Books = books;
		}

		public void AddBook(string newBook)
        {

			if (Books.Count == 0)
			{
				Books.AddFirst(newBook);
			}
			else
			{
				bool wasAdded = false;
				foreach (string book in Books)
				{
					if (newBook[0] <= book[0])
                    {
						Books.AddBefore(Books.Find(book), newBook);
						wasAdded = true;
						break;
                    }
				}
				if (!wasAdded)
					Books.AddLast(newBook);
			}
		}
	}
}
