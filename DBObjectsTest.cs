using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
#pragma warning disable 618

namespace Autocad_obgect_id
{
    public class DBObjectsTest
    {
        //работа с обьектами БД чертежа
        [CommandMethod("DBObjectsTest")]
        public void DBObjectsTestRun()
        {
            ObjectId entId= new ObjectId();
            Document adoc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = adoc.Editor;
            Database db = adoc.Database;
            PromptEntityResult entRes = ed.GetEntity("\n выберите обьект: ");
            if (entRes.Status != PromptStatus.OK) return;
            entId = entRes.ObjectId;
            bool IsCorrect = !entId.IsNull
               && entId.IsValid
               && !entId.IsErased
               && !entId.IsEffectivelyErased
               && entId.ObjectClass.Name.Equals("AcDbLine");
            if (!IsCorrect)
            {
                ed.WriteMessage("\n обьект некоректный!");
                return;
            }
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {

                tr.Commit();
            }
        }
    }
}
