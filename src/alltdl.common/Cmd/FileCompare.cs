namespace alltdl.Cmd;

// This implementation defines a very simple comparison between two FileInfo objects. It only compares the name of the files being compared and their length in bytes.
internal class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
{
    public FileCompare()
    { }

    public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
    {
        return (f1.Name == f2.Name &&
                f1.Length == f2.Length);
    }

    // Return a hash that reflects the comparison criteria. According to the rules for IEqualityComparer<T>, if Equals is true, then the hash codes must also be equal. Because
    // equality as defined here is a simple value equality, not reference identity, it is possible that two or more objects will produce the same hash code.
    public int GetHashCode(System.IO.FileInfo fi)
    {
        string s = $"{fi.Name}{fi.Length}";
        return s.GetHashCode();
    }
}

internal class ValueEqualityExampleObjectA : IEquatable<ValueEqualityExampleObjectA>
{
    public ValueEqualityExampleObjectA(int x, int y)
    {
        if (x is (< 1 or > 2000) || y is (< 1 or > 2000))
        {
            throw new ArgumentException("Point must be in range 1 - 2000");
        }
        this.X = x;
        this.Y = y;
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public static bool operator !=(ValueEqualityExampleObjectA lhs, ValueEqualityExampleObjectA rhs) => !(lhs == rhs);

    public static bool operator ==(ValueEqualityExampleObjectA lhs, ValueEqualityExampleObjectA rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }

        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }

    public override bool Equals(object obj) => this.Equals(obj as ValueEqualityExampleObjectA);

    public bool Equals(ValueEqualityExampleObjectA p)
    {
        if (p is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, p))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (this.GetType() != p.GetType())
        {
            return false;
        }

        // Return true if the fields match. Note that the base class is not invoked because it is System.Object, which defines Equals as reference equality.
        return (X == p.X) && (Y == p.Y);
    }

    public override int GetHashCode() => (X, Y).GetHashCode();
}

// For the sake of simplicity, assume a ThreeDPoint IS a TwoDPoint.
internal class ValueEqualityExampleObjectB : ValueEqualityExampleObjectA, IEquatable<ValueEqualityExampleObjectB>
{
    public ValueEqualityExampleObjectB(int x, int y, int z)
        : base(x, y)
    {
        if ((z < 1) || (z > 2000))
        {
            throw new ArgumentException("Point must be in range 1 - 2000");
        }
        this.Z = z;
    }

    public int Z { get; private set; }

    public static bool operator !=(ValueEqualityExampleObjectB lhs, ValueEqualityExampleObjectB rhs) => !(lhs == rhs);

    public static bool operator ==(ValueEqualityExampleObjectB lhs, ValueEqualityExampleObjectB rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                // null == null = true.
                return true;
            }

            // Only the left side is null.
            return false;
        }

        // Equals handles the case of null on right side.
        return lhs.Equals(rhs);
    }

    public override bool Equals(object obj) => this.Equals(obj as ValueEqualityExampleObjectB);

    public bool Equals(ValueEqualityExampleObjectB p)
    {
        if (p is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, p))
        {
            return true;
        }

        // Check properties that this class declares.
        if (Z == p.Z)
        {
            // Let base class check its own fields and do the run-time type comparison.
            return base.Equals((ValueEqualityExampleObjectA)p);
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode() => (X, Y, Z).GetHashCode();
}

internal class ExampleMethods
{
    private static void RunValueEqualityExample()
    {
        ValueEqualityExampleObjectB pointA = new ValueEqualityExampleObjectB(3, 4, 5);
        ValueEqualityExampleObjectB pointB = new ValueEqualityExampleObjectB(3, 4, 5);
        ValueEqualityExampleObjectB pointC = null;
        int i = 5;

        Console.WriteLine("pointA.Equals(pointB) = {0}", pointA.Equals(pointB));
        Console.WriteLine("pointA == pointB = {0}", pointA == pointB);
        Console.WriteLine("null comparison = {0}", pointA.Equals(pointC));
        Console.WriteLine("Compare to some other type = {0}", pointA.Equals(i));

        ValueEqualityExampleObjectA pointD = null;
        ValueEqualityExampleObjectA pointE = null;

        Console.WriteLine("Two null TwoDPoints are equal: {0}", pointD == pointE);

        pointE = new ValueEqualityExampleObjectA(3, 4);
        Console.WriteLine("(pointE == pointA) = {0}", pointE == pointA);
        Console.WriteLine("(pointA == pointE) = {0}", pointA == pointE);
        Console.WriteLine("(pointA != pointE) = {0}", pointA != pointE);

        System.Collections.ArrayList list = new System.Collections.ArrayList();
        list.Add(new ValueEqualityExampleObjectB(3, 4, 5));
        Console.WriteLine("pointE.Equals(list[0]): {0}", pointE.Equals(list[0]));

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

/* Output:
    pointA.Equals(pointB) = True
    pointA == pointB = True
    null comparison = False
    Compare to some other type = False
    Two null TwoDPoints are equal: True
    (pointE == pointA) = False
    (pointA == pointE) = False
    (pointA != pointE) = True
    pointE.Equals(list[0]): False
*/