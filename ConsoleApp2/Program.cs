// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

student s1 = new student("sahasra", "efg", 1, 43);
student s2 = new student("akash", "efg", 2, 36);
student s3 = new student("sam", "efg", 3, 56);


//Console.WriteLine(s1 == s2);
//Console.WriteLine(s1.Equals(s2));
//HashSet<student> myset = new HashSet<student>();
//myset.Add(s2);
//myset.Add(s1);
//Console.WriteLine(myset.Count);
//Dictionary< student,string> d = new Dictionary<student, string>();
//d.Add(s1, "abc");
//d.Add(s2, "abc");

/*PriorityQueue<student,int> pq = new PriorityQueue<student,int>();
pq.Enqueue(s2)*/

List<student> ls = new List<student>();
ls.Add(s2);
ls.Add(s1);
ls.Add(s3);
ls.Sort(new studentidcomparer() );
Console.WriteLine("hello");
ls.Sort()
class student:IComparable
{
    string name;
    string lastname;
    public int id;
    public int birthyear;
    public student (string e ,string l, int i, int b)
    {
        this.name = e;
        this.lastname = l;
        this.id = i;
        this.birthyear = b;

    }

    //public int CompareTo(object? obj)
    //{
    //    return id.CompareTo(obj);
    //}

    public override bool Equals(object? obj)
    {
        bool answer = false;
        student other = obj as student;
        return this.name == other.name && this.lastname ==other.lastname;
    }

    public int CompareTo(object? obj)
    {
        student other = obj as student;
        return other.birthyear - this.birthyear;

    }
    public override int GetHashCode()
    {
        return this.name.GetHashCode() + this.lastname.GetHashCode();
    }
}

class studentbirthyearcomparer : IComparer<student>
{
    public int Compare(student? x, student? y)
    {
        return x.birthyear - y.birthyear;
    }
}

class studentidcomparer : IComparer<student>
{
    public int Compare(student? x, student? y)
    {
        return x.id - y.id;
    }
}