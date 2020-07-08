using System.Diagnostics;
using System.Threading.Tasks;
using Godot;
using System.Collections.Concurrent;

public class NodeManagerTest : Spatial
{
  [Export]
  readonly PackedScene TestChildNode;

  ConcurrentQueue<TestChildNode> testQueue
  = new ConcurrentQueue<TestChildNode>();

  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    for (int i = 0; i < 3; i++) {
      TestChildNode testChildNode = (TestChildNode)TestChildNode.Instance();
      //testChildNode.SetIgnoreTransformNotification(true);
      testQueue.Enqueue(testChildNode);
    }

    Task.Run(() => {
      for (int i = 0; i < 3; i++) {
        if (testQueue.TryDequeue(out TestChildNode testChild)) {
          testChild.setTestPropTrue();
          GD.Print($"fin");
        }
      }
    });
  }
}
