using SeededDatabase.Context;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeededDatabase.Seeder
{
    public class SeedFromConfigFiles
    {
        private readonly string _importLocation = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + Path.DirectorySeparatorChar + "Configuration";
        private readonly string _archiveLocation;
        private readonly SeededDatabaseContext _context;

        public SeedFromConfigFiles(SeededDatabaseContext databaseContext)
        {
            Directory.CreateDirectory(_importLocation);
            _context = databaseContext;
            _archiveLocation = _importLocation + Path.DirectorySeparatorChar + "archive";
            Unzip();
        }

        private void Unzip()
        {
            var zip = Directory.GetFiles(_importLocation).Where(x => x.Contains(".zip"));
            foreach (var zipFile in zip)
            {
                var jsonFiles = Directory.GetFiles(_importLocation).Where(x => x.Contains(".json"));
                foreach (var jsonFile in jsonFiles)
                {
                    Directory.CreateDirectory(_archiveLocation);
                    var archiveFile = _archiveLocation + Path.DirectorySeparatorChar + Path.GetFileName(jsonFile);
                    if (File.Exists(archiveFile))
                    {
                        File.Delete(archiveFile);
                    }
                    File.Move(jsonFile, archiveFile);
                }

                ZipFile.ExtractToDirectory(zipFile, _importLocation);

                if (File.Exists(zipFile))
                {
                    Directory.CreateDirectory(_archiveLocation);
                    var archiveFile = _archiveLocation + Path.DirectorySeparatorChar + Path.GetFileName(zipFile);
                    if (File.Exists(archiveFile))
                    {
                        File.Delete(archiveFile);
                    }
                    File.Move(zipFile, archiveFile);
                }
            }
        }

        public void ImportCalculationReferences()
        {
            var serial = File.ReadAllText(_importLocation + Path.DirectorySeparatorChar + "CalculationReferences.json");
            var references = JsonSerializer.Deserialize<List<CalculationReference>>(serial);
            if (references != null)
            {
                _context.CalculationReferences.AddRange(references);
                _context.SaveChanges();
            }
        }
    }
}

