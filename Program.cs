using PicoGK;
using Leap71.ShapeKernel;

class Program
{
    private static string strOutputFolder = "C:/Development/Leap71/Exports";
    private static string strInputFolder = "C:/Users/dkLukSmo/Downloads/topOptBody.stl";

    static void Main(string[] args)
    {
        // Initialize the library with appropriate arguments
        Library.Go(1.0f, new ThreadStart(ProcessMeshTask), strOutputFolder, "logfilename.log", "lightsfile.lights");
    }

    private static void ProcessMeshTask()
    {
        try
        {
            Mesh mesh = Mesh.mshFromStlFile(strInputFolder);
            Voxels voxPart = new Voxels(mesh);
            Voxels offsetPart = Sh.voxOffset(voxPart, 0.5f);
            Sh.ExportVoxelsToSTLFile(offsetPart, strOutputFolder);
        }
        catch (Exception e)
        {
            Library.Log("Failed to run ProcessMeshTask.");
            Library.Log(e.ToString());
            Library.oViewer().SetBackgroundColor(Cp.clrWarning);
        }
    }
}
