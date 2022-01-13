using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    internal static class Program
    {
        private static void Main( string[] args )
        {
            //var uniqueValues = new Dictionary<string, HashSet<object>>();

            //foreach ( var file in Directory.EnumerateFiles( @"D:\Users\smart\Documents\Visual Studio 2017\Projects\DumpEVTFiles\DumpEVTFiles\bin\Debug\evts", "*.EVT" ) )
            //{
            //    var evt = new EvtFile( file );
            //    foreach ( var command in evt.Commands )
            //    {
            //        if ( command.Type == "Msg_" )
            //        {
            //            foreach ( var field in typeof( MsgCommandData ).GetProperties() )
            //            {
            //                if ( !uniqueValues.ContainsKey( field.Name ) )
            //                    uniqueValues[ field.Name ] = new HashSet<object>();

            //                uniqueValues[ field.Name ].Add( field.GetValue( command.Data ) );
            //            }
            //        }
            //    }
            //}

            //foreach ( var field in uniqueValues.Keys )
            //{
            //    Console.Write( $"{field}:" );
            //    foreach ( var o in uniqueValues[field] )
            //    {
            //        Console.Write( $" {o}," );
            //    }
            //    Console.WriteLine(  );
            //}
            //return;

            if ( args.Length == 0 )
            {
                Console.WriteLine( "EvtTool 1.4 by TGE\n" +
                                   "\n" +
                                   "Usage:\n" +
                                   "EvtTool <file path>\n" +
                                   "Drag .EVT, .ECS or .lsd file onto the program to convert to JSON, drag JSON file to convert back.\n" );
                return;
            }

            var path = args[0];
            if ( !File.Exists( path ) )
            {
                Console.WriteLine( "Specified file doesn't exist." );
                return;
            }

            if ( path.EndsWith( "json", StringComparison.InvariantCultureIgnoreCase ) )
            {
                var json = File.ReadAllText( path );
                ISaveable file;
                var settings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error };

                try
                {
                    if ( path.EndsWith( ".EVT.json", StringComparison.InvariantCultureIgnoreCase ) )
                    {
                        file = JsonConvert.DeserializeObject<EvtFile>( json, settings );
                    }
                    else if ( path.EndsWith( ".ECS.json", StringComparison.InvariantCultureIgnoreCase ) )
                    {
                        file = JsonConvert.DeserializeObject<EcsFile>( json, settings );
                    }
                    else if ( path.EndsWith( ".lsd.json", StringComparison.InvariantCultureIgnoreCase ) )
                    {
                        file = new LsdFile( JsonConvert.DeserializeObject<List<LsdList>>( json, settings ) );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Unrecognized source file type. Did you alter the extension of the file? Expected name format is 'filename.format.json'" );
                        return;
                    }
                }
                catch ( Exception )
                {
                    Console.WriteLine( "Error occured while deserializing JSON. The JSON provided is either corrupt or incompatible." );
                    return;
                }

                file.Save( Path.ChangeExtension( path, null ) );
            }
            else
            {
                var extension = "EVT.json";
                object obj;

                if ( path.EndsWith( "evt", StringComparison.InvariantCultureIgnoreCase ) )
                {
                    obj = new EvtFile( path );
                }
                else if ( path.EndsWith( "ecs", StringComparison.InvariantCultureIgnoreCase ) )
                {
                    obj = new EcsFile( path );
                    extension = "ECS.json";
                }
                else if ( path.EndsWith( "lsd", StringComparison.InvariantCultureIgnoreCase ) )
                {
                    var lsd = new LsdFile( path );
                    obj = lsd.Lists;
                    extension = "lsd.json";
                }
                else
                {
                    Console.WriteLine( "Unrecognized file type." );
                    return;
                }

                var json = JsonConvert.SerializeObject( obj, Formatting.Indented );
                File.WriteAllText( Path.ChangeExtension( path, extension ), json );
            }
        }
    }
}
