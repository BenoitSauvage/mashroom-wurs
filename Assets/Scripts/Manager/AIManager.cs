using UnityEngine;
using System.Collections;

public class AIManager {
    
    #region singleton
    private static AIManager instance;

    private AIManager() { }

    public static AIManager Instance {
        get {
            if (instance == null)
                instance = new AIManager();

            return instance;
        }
    }
    #endregion singleton
}
