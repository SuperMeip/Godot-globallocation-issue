using Godot;
using System;

public class TestChildNode : Spatial{
    
  /// <summary>
  /// If this chunk has been meshed with chunk data.
  /// </summary>
  public bool testProp{
    get;
    private set;
  } = false;

  public void setTestPropTrue() {
    testProp = true;
  }
}
