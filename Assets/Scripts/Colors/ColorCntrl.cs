using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ColorCntrl
{
    private List<Color> _colors;
    private Random _random;
    private int _currentIndexColor = -1;

    public ColorCntrl()
    {
        _colors = GeneateColors();
        _random = new Random();
        _currentIndexColor = 0;
    }

    public List<Color> GeneateColors()
    {
        List<Color> colors = new List<Color>();
        for (float i = 0; i <= 1; i += 0.5f)
        {
            for (float j = 0; j <= 1; j += 0.5f)
            {
                for (float k = 0; k <= 1; k += 0.5f)
                {
                    colors.Add(new Color(i,j,k,1));
                }
            }
        }
        return colors;
    }

    public void ShuffleColors()
    {
        int n = _colors.Count;
        while (n > 1)
        {
            int k = _random.Next(--n);
            (_colors[n], _colors[k]) = (_colors[k], _colors[n]);
        }
    }

    public Color GetNextColor()
    {
        _currentIndexColor = (_currentIndexColor+1) % _colors.Count;
        return _colors[_currentIndexColor];
    }

    public Color GetRandomColor()
    {
        return _colors[_random.Next(_colors.Count)];
    }
}