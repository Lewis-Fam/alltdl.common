namespace alltdl.Cmd;

public class CompareDirs
{
    public static void Compare()
    {
        // Create two identical or different temporary folders on a local drive and change these file paths.
        string pathA = @"C:\TestDir";
        string pathB = @"C:\TestDir2";

        System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(pathA);
        System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(pathB);

        // Take a snapshot of the file system.
        IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
        IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

        //A custom file comparer defined below
        FileCompare myFileCompare = new FileCompare();

        // This query determines whether the two folders contain identical file lists, based on the custom file comparer that is defined in the FileCompare class. The query
        // executes immediately because it returns a bool.
        bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

        if (areIdentical == true)
        {
            Console.WriteLine("the two folders are the same");
        }
        else
        {
            Console.WriteLine("The two folders are not the same");
        }

        // Find the common files. It produces a sequence and doesn't execute until the foreach statement.
        var queryCommonFiles = list1.Intersect(list2, myFileCompare);

        if (queryCommonFiles.Any())
        {
            Console.WriteLine("The following files are in both folders:");
            foreach (var v in queryCommonFiles)
            {
                Console.WriteLine(v.FullName); //shows which items end up in result list
            }
        }
        else
        {
            Console.WriteLine("There are no common files in the two folders.");
        }

        // Find the set difference between the two folders. For this example we only check one way.
        var queryList1Only = (from file in list1
                              select file).Except(list2, myFileCompare);

        Console.WriteLine("The following files are in list1 but not list2:");
        foreach (var v in queryList1Only)
        {
            Console.WriteLine(v.FullName);
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}