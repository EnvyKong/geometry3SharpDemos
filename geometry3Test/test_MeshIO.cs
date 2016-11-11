﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using g3;

namespace geometry3Test
{
    public class test_MeshIO
    {
        public static void test_simple_obj()
        {
            string cwd = System.IO.Directory.GetCurrentDirectory();

            System.Console.WriteLine("MeshIOTests : test_simple_obj() starting");

            //SimpleMeshBuilder builder = new SimpleMeshBuilder();
            DMesh3Builder builder = new DMesh3Builder();
            StandardMeshReader reader = new StandardMeshReader();
            reader.MeshBuilder = builder;
            var readResult = reader.Read(Program.TEST_FILES_PATH + "socket_with_groups.obj", new ReadOptions());

            System.Console.WriteLine("read complete");

            if (readResult.result != ReadResult.Ok) {
                System.Console.WriteLine("read failed : " + readResult.info);
                throw new Exception("failed");
            }

            var writeResult = StandardMeshWriter.WriteFile(Program.TEST_OUTPUT_PATH + "temp_write.obj",
                builder.Meshes.Cast<IMesh>().ToList(), new WriteOptions());

            System.Console.WriteLine("write complete");

            if (writeResult.result != WriteResult.Ok) {
                System.Console.WriteLine("write failed : " + writeResult.info);
                throw new Exception("fuck");
            }
        }


    }
}