// See https://aka.ms/new-console-template for more information
//Console.WriteLine("请输入路径,默认是当前目录");
//string? path = Console.ReadLine();
//string rootPath = Directory.GetCurrentDirectory();

//Console.WriteLine("请输入输出目录，");
//string? dirPath = Console.ReadLine();
//while(dirPath == null || dirPath == "") {
//    Console.WriteLine("请输入输出目录，");
//    dirPath = Console.ReadLine();
//}
//DirectoryInfo info;
//if(path == null || path == "") {
//    info = new DirectoryInfo(rootPath);
//} else {
//    info = new DirectoryInfo(path);
//}


//FileInfo[] files = info.GetFiles();
//int i = -1;
//foreach(var item in files) {

//    i++;
//    string nPath = $"{dirPath}\\{i}{Path.GetExtension(item.FullName)}";
//    File.Copy(item.FullName, nPath);

//}
//Console.WriteLine("修改完成");
Person zaks = new Person() { Name = "zaks" };
Console.WriteLine(zaks.Name);
Person a = (Person)zaks.Clone();
a.Name = "aaa";
Console.WriteLine(a.Name);
Console.WriteLine(zaks.Name);

// 以上是浅copy



class Person : ICloneable {
    public string Name { get; set; }

    public object Clone() {
        return this.MemberwiseClone();
    }
}

