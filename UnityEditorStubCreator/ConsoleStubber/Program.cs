namespace ConsoleStubber
{
    using System;
    using AssemblyStripper;
    using System.IO;
    using Newtonsoft.Json;

    public static class Program
    {
        public static void Main(String[] args)
        {
            String json = File.ReadAllText("ConsoleStubber.json");
            dynamic jsonResults = JsonConvert.DeserializeObject<dynamic>(json);
            StubbingOptions options = new StubbingOptions
            {
                outputReferenceStub = jsonResults.outputReferenceStub,
                makeReferenceStubPublic = jsonResults.makeReferenceStubPublic,
                outputEditorStub = jsonResults.outputEditorStub,
                makeEditorStubPublic = jsonResults.makeEditorStubPublic,
                outputForwardAssembly = jsonResults.outputForwardAssembly,
                outputPath = jsonResults.outputPath,
                targetAssemblyPath = jsonResults.targetAssemblyPath,
                editorRenameTo = jsonResults.editorRenameTo,
                removeNonSerializedTypesForEditor = jsonResults.removeNonSerializedTypesForEditor,
                removeReadonly = jsonResults.removeReadonly
            };
            Console.WriteLine(Stubber.StubAssembly(options) ? "Success" : "Failed");
        }
    }
}
