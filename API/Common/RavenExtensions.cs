﻿using Domain;
using Persistence;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common
{
    public static class RavenExtensions
    {
        public static void SeedData(this IDocumentSession session)
        {
            var cultureInfo = new CultureInfo("pl-PL");

            using (session)
            {
                var query = from Book in session.Query<Book>() select Book;
                var result = query.ToList();
                if (result.Count != 0) return;
            }

            var books = new List<Book>
            {
                new Book()
                {
                    Title= "Title",
                    Author = "Author",
                    Publisher = "Publisher",
                    Published = new DateOnly(1998,1,1),
                    Category = "Category",
                    Description = "Description",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 1,
                        Borrowed = 0
                    }
                },

                new Book()
                {
                    Title = "Ołowiany Świt",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2013,4,26),
                    Category = "Fantastyka",
                    Description = "Zona - tajemnica, która wciąga, kusi i intryguje.\r\n\r\nJej historią jest świat współczesny. Jej dzieci to my.\r\n\r\nUniwersum S.T.A.L.K.E.R.a oczami Polaka – stara mleczarnia, martwy cieć, zapomniany kalendarz i wieża w środku lasu.\r\n\r\nWchodzisz w to? Zresztą, już jesteś. Wszyscy jesteśmy – stalkerami. Dziećmi Sarkofagu.\r\n\r\nTutaj wrogiem jest zło, które może czaić się tuż obok, za naszymi plecami. Może przyjmować różne postaci, imiona i kształty; jednak najstraszniejszym, co możemy spotkać w Zonie - jest człowiek.\r\n\r\nWstaje nowy dzień. Czy przeżyjesz go - całym sobą?",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 100,
                        Borrowed = 0
                    }
                },

                new Book()
                {
                    Title = "Stalowe Szczury. Błoto",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2015,1,1),
                    Category = "Fantastyka",
                    Description = "Wiosna 1922. Samobójcze natarcie na pozycje przeciwnika po raz kolejny prowadzi kapral Reinhardt i jego kompania karna – kundle wojny, dezerterzy, podpalacze i najgorsze szumowiny. Straceńcy gotowi na wszystko.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 150,
                        Borrowed = 0
                    }
                },

                new Book()
                {
                    Title = "Komornik",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2016,1,1),
                    Category = "Fantastyka",
                    Description = "Nadchodzi Koniec.\r\nAle taki w cholerę prawdziwy, biblijny. Ziemia zatrzymuje się, gwiazdy spadają, woda zamienia się w krew. Umarli wstają z grobów, otwiera się otchłań. Państwa upadają, brat powstaje przeciw bratu, a dzieci podnoszą rękę na rodziców. Widać, że lada chwila świat spłonie.\r\nTylko że coś w systemie nie zaskoczyło. Generalnie, zasadniczo i pobieżnie: zamiast bomby termojądrowej wychodzi fajerwerk.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 80,
                        Borrowed = 0
                    }
                },

                new Book()
                {
                    Title = "Inside RavenDB 4.0",
                    Author = "Oren Eini",
                    Publisher = "HybernatingRhinos",
                    Published = new DateOnly(2017,1,1),
                    Category = "Poradniki",
                    Description = "What you're reading now is effectively a book-length blog post. The main idea here is that I want to give you a way to grok RavenDB.2 This means not only gaining knowledge of what RavenDB does, but also all the reasoning behind the bytes. In effect, I want you to understand all the whys of RavenDB.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 200,
                        Borrowed = 0
                    }
                },
            };

            using (session)
            {
                foreach (var book in books)
                {
                    session.Store(book);
                }

                session.SaveChanges();
                Console.WriteLine("Seed succesful");
            }
        }
    }
}