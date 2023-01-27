using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Geometry;

namespace Autocad_obgect_id
{
  public class CreateLayout
    {
        int lay_counter = 0;
        //27-01-2023 
        // создание нового листа
        // Create a new layout with the LayoutManager
        [CommandMethod("F_CreateLayout")]
    public void CreateLayout_Void()
    {
        // Get the current document and database
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;

        // Get the layout and plot settings of the named pagesetup
        using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
        {
            // Reference the Layout Manager
            LayoutManager acLayoutMgr = LayoutManager.Current;
                // ввод имeни листа
                string lay_Name;
               
                lay_counter++;
               // acDoc.Editor.GetString(lay_Name);
            // Create the new layout with default settings

            ObjectId objID = acLayoutMgr.CreateLayout("newLayout" + lay_counter.ToString());

            // Open the layout
            Layout acLayout = acTrans.GetObject(objID,
                                                OpenMode.ForRead) as Layout;

            // Set the layout current if it is not already
            if (acLayout.TabSelected == false)
            {
                acLayoutMgr.CurrentLayout = acLayout.LayoutName;
            }

            // Output some information related to the layout object
            acDoc.Editor.WriteMessage("\nTab Order: " + acLayout.TabOrder +
                                      "\nTab Selected: " + acLayout.TabSelected +
                                      "\nBlock Table Record ID: " +
                                      acLayout.BlockTableRecordId.ToString());

            // Save the changes made
            acTrans.Commit();
        }
    }
}
}
