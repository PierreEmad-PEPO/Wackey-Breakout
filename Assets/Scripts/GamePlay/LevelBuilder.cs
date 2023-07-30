using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private const float offset = 1.15f;
    private const float screenRatio = 0.2f;
    private const int rowsNum = 3;
    [SerializeField] private GameObject paddle;
    [SerializeField] private GameObject Block;
    [SerializeField] private GameObject FreezeBlock;
    [SerializeField] private GameObject SpeedBlock;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle);

        for(float x = ScreenUtils.ScreenLeft - ScreenUtils.ScreenLeft * screenRatio; x <= ScreenUtils.ScreenRight - ScreenUtils.ScreenRight*screenRatio; x += offset)
        {
            int cnt = 0;
            for (float y = ScreenUtils.ScreenTop - ScreenUtils.ScreenTop * screenRatio; cnt < rowsNum ; y -= offset, cnt++)
            {
                int random = Random.Range(0, 3);
                if (random == 0)
                    Instantiate(Block, new Vector2(x, y), Quaternion.identity);
                else if (random == 1)    
                    Instantiate(FreezeBlock, new Vector2(x, y), Quaternion.identity);
                else if (random == 2)    
                    Instantiate(SpeedBlock, new Vector2(x, y), Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
