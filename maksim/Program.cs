using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maksim
{
    internal class Program
    {
        enum TimeFrame
        {
            Year,
            TwoYears,
            Long

        }
        class Paper
        {
            public string Name { get; set; }
            public Person Author { get; set; }
            public DateTime Date { get; set; }
            public Paper(string name, Person author, DateTime date)
            {
                this.Name = name;
                this.Author = author;
                this.Date = date;
            }
            public Paper()
            {
                this.Name = "Unknown";
                this.Author = null;
                this.Date = DateTime.MinValue;
            }
            public string ToFullString()
            {
                return $"{Name}\n{Author.Name}\n{Author.Surname}\n{Author.BirthDate}\n{Date}";
            }
        }
        class ResearchTeam
        {
            private string topic;
            private string organizationName;
            private int id;
            private TimeFrame researchDuration;
            private Paper[] paperList;

            public string Topic
            {
                get { return topic; }
                set { topic = value; }
            }
            public string OrganizationName
            {
                get { return organizationName; }
                set { organizationName = value; }
            }
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public TimeFrame ResearchDuration
            {
                get { return researchDuration; }
                set { researchDuration = value; }
            }
            public Paper[] PaperList
            {
                get { return paperList; }
                set { paperList = value; }
            }
            public Paper LatestPaper
            {
                get
                {
                    if (paperList.Length == 0) return null;
                    else
                    {
                        return paperList.OrderByDescending(p => p.Date).FirstOrDefault();
                    }
                }
            }
            public ResearchTeam(string topic, string organizationName, int id, TimeFrame researchDuration)
            {
                this.topic = topic;
                this.organizationName = organizationName;
                this.id = id;
                this.researchDuration = researchDuration;
            }
            public ResearchTeam()
            {
                this.topic = "Unknown";
                this.organizationName = "Unknown";
                this.id = 0;
                this.researchDuration = 0;
                this.paperList = new Paper[] { };
            }
            public void AddPapers(params Paper[] newPapers)
            {
                if (paperList == null)
                {
                    paperList = newPapers;
                    return;
                }
                var currentList = paperList.ToList();
                currentList.AddRange(newPapers);
                paperList = currentList.ToArray();
            }
            public string ToFullString()
            {
                string fullString = $"{topic}\n{organizationName}\n{id}\n{researchDuration}";
                for (int i=  0; i < paperList.Length; i++)
                {
                    fullString += $"{paperList[i].Name}\n{paperList[i].Author.Name}\n{paperList[i].Author.Surname}\n{paperList[i].Author.BirthDate}\n{paperList[i].Date}\n";
                }
                return fullString ;
            }
            public string ToShortString()
            {
                return $"{topic}\n{organizationName}\n{id}\n{researchDuration}";
            }
        }
        class Person
        {
            private string name;
            private string surname;
            private DateTime birthDate;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }
            public DateTime BirthDate
            {
                get { return birthDate; }
                set { birthDate = value; }
            }
            public int BirthYear
            {
                get { return birthDate.Year; }
                set
                {
                    birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
                }
            }
            public string ToFullString()
            {
                return $"{name}\n{surname}\n{birthDate}";
            }
            public string ToShortString()
            {
                return $"{name}\n{surname}";
            }
            public Person(string name, string surname, DateTime birthDate)
            {
                this.name = name;
                this.surname = surname;
                this.birthDate = birthDate;
            }
            public Person()
            {
                this.name = "Unknown";
                this.surname = "Unknown";
                this.birthDate = DateTime.MinValue;
            }
        }
        static void Main(string[] args)
        {
            ResearchTeam team1 = new ResearchTeam("снюсик", "команда1", 12345, TimeFrame.Year);
            Console.WriteLine($"{team1.ToShortString()}\n");

            Person person1 = new Person("витя", "самогон", DateTime.Now);
            Paper paper1 = new Paper("книга1", person1, new DateTime(2024, 11, 22));
            Paper paper2 = new Paper("книга2", person1, new DateTime(2024, 11, 23));
            Paper[] team1_papers = new Paper[] { paper1, paper2 };
            team1.AddPapers(team1_papers);
            Console.WriteLine($"{team1.ToFullString()}\n");

            Console.WriteLine(team1.LatestPaper);

            Console.ReadKey();

        }
    }
}
