using dnlib.DotNet;
using System;
using dnlib.DotNet.Emit;
using System.Linq;
using System.Text;
using dnlib.DotNet.Writer;
using System.IO;

namespace BreakFreeAudioKeyMaker
{
    public class TuneAero
    {
        public static bool Patch(string filePath)
        {
            try
            {
                string backupFilePath = filePath + DateTime.Now.ToString("yyyymmddMMss");
                File.Move(filePath, backupFilePath);

                ModuleDefMD module = ModuleDefMD.Load(backupFilePath);

                MethodDef targetMethod = module.FindNormal("License.LicenseInfo").Methods.FirstOrDefault(method => method.Name == "get_IsUnlocked");

                var instructions = targetMethod.Body.Instructions;

                if (instructions.Count == 5)
                {
                    instructions.Clear();

                    instructions.Add(OpCodes.Ldc_I4_1.ToInstruction());
                    instructions.Add(OpCodes.Ret.ToInstruction());

                    module.Write(filePath);

                    return true;
                } 
                else if (instructions.Count == 2)
                {
                    Console.WriteLine("Already patched");
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
