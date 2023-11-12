using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetDataExtractorPro.InfoGMS2
{
    public class Asset
    {
        public SpriteId spriteId { get; set; }
        public double headPosition { get; set; }
        public double rotation { get; set; }
        public double scaleX { get; set; }
        public double scaleY { get; set; }
        public double animationSpeed { get; set; }
        public object colour { get; set; }
        public object inheritedItemId { get; set; }
        public bool frozen { get; set; }
        public bool ignore { get; set; }
        public bool inheritItemSettings { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public List<object> tags { get; set; }
        public string resourceType { get; set; }
    }

    public class Layer
    {
        public List<Asset> assets { get; set; }
        public bool visible { get; set; }
        public long depth { get; set; }
        public bool userdefinedDepth { get; set; }
        public bool inheritLayerDepth { get; set; }
        public bool inheritLayerSettings { get; set; }
        public long gridX { get; set; }
        public long gridY { get; set; }
        public List<object> layers { get; set; }
        public bool hierarchyFrozen { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public List<object> tags { get; set; }
        public string resourceType { get; set; }
        public List<object> instances { get; set; }
        public object spriteId { get; set; }
        public long? colour { get; set; }
        public long? x { get; set; }
        public long? y { get; set; }
        public bool? htiled { get; set; }
        public bool? vtiled { get; set; }
        public double? hspeed { get; set; }
        public double? vspeed { get; set; }
        public bool? stretch { get; set; }
        public double? animationFPS { get; set; }
        public long? animationSpeedType { get; set; }
        public bool? userdefinedAnimFPS { get; set; }

        public override string ToString()
        {
            return $"{name} ({resourceType})";
        }
    }

    public class Parent
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class PhysicsSettings
    {
        public bool inheritPhysicsSettings { get; set; }
        public bool PhysicsWorld { get; set; }
        public double PhysicsWorldGravityX { get; set; }
        public double PhysicsWorldGravityY { get; set; }
        public double PhysicsWorldPixToMetres { get; set; }
    }

    public class RoomSettings
    {
        public bool inheritRoomSettings { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public bool persistent { get; set; }
    }

    public class RoomYY
    {
        public bool isDnd { get; set; }
        public double volume { get; set; }
        public object parentRoom { get; set; }
        public List<View> views { get; set; }
        public List<Layer> layers { get; set; }
        public bool inheritLayers { get; set; }
        public string creationCodeFile { get; set; }
        public bool inheritCode { get; set; }
        public List<object> instanceCreationOrder { get; set; }
        public bool inheritCreationOrder { get; set; }
        public object sequenceId { get; set; }
        public RoomSettings roomSettings { get; set; }
        public ViewSettings viewSettings { get; set; }
        public PhysicsSettings physicsSettings { get; set; }
        public Parent parent { get; set; }
        public string resourceVersion { get; set; }
        public string name { get; set; }
        public List<object> tags { get; set; }
        public string resourceType { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class SpriteId
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class View
    {
        public bool inherit { get; set; }
        public bool visible { get; set; }
        public int xview { get; set; }
        public int yview { get; set; }
        public int wview { get; set; }
        public int hview { get; set; }
        public int xport { get; set; }
        public int yport { get; set; }
        public int wport { get; set; }
        public int hport { get; set; }
        public int hborder { get; set; }
        public int vborder { get; set; }
        public int hspeed { get; set; }
        public int vspeed { get; set; }
        public object objectId { get; set; }
    }

    public class ViewSettings
    {
        public bool inheritViewSettings { get; set; }
        public bool enableViews { get; set; }
        public bool clearViewBackground { get; set; }
        public bool clearDisplayBuffer { get; set; }
    }
}
