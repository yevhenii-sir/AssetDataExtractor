using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetDataExtractorPro.InfoGMS2
{
    internal class ProjectYYP
    {
        public List<Resource> resources { get; set; }
        public List<Option> Options { get; set; }
        public bool isDnDProject { get; set; }
        public bool isEcma { get; set; }
        public string tutorialPath { get; set; }
        public Configs configs { get; set; }
        public List<RoomOrderNode> RoomOrderNodes { get; set; }
        public List<Folder> Folders { get; set; }
        public List<AudioGroup> AudioGroups { get; set; }
        public List<TextureGroup> TextureGroups { get; set; }
        public List<IncludedFile> IncludedFiles { get; set; }
        public MetaData MetaData { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public List<object> tags { get; set; }
        public string resourceType { get; set; }
    }

    public class AudioGroup
    {
        public long targets { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public string resourceType { get; set; }
    }

    public class Configs
    {
        public string name { get; set; }
        public List<object> children { get; set; }
    }

    public class Folder
    {
        public string folderPath { get; set; }
        public long order { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public List<object> tags { get; set; }
        public string resourceType { get; set; }
    }

    public class Id
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class IncludedFile
    {
        public long CopyToMask { get; set; }
        public string filePath { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public string resourceType { get; set; }
    }

    public class MetaData
    {
        public string IDEVersion { get; set; }
    }

    public class Option
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class Resource
    {
        public Id id { get; set; }
        public long order { get; set; }
    }

    public class RoomId
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class RoomOrderNode
    {
        public RoomId roomId { get; set; }
    }
    public class TextureGroup
    {
        public bool isScaled { get; set; }
        public bool autocrop { get; set; }
        public int border { get; set; }
        public int mipsToGenerate { get; set; }
        public object groupParent { get; set; }
        public long targets { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public string resourceType { get; set; }
    }
}
