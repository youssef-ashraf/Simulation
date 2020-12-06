﻿

public class NeuralNetwork
{
    public int hiddenLayer =1 ;
    public int size_hidden_layers = 5 ;
    public int outputs = 1 ;
    public int inputs = 5 ;
    public float maxInitialValue = 1f ;

    private const float EULER_NUMBER = 2.71828f ;
    private List <List<float>> neurons ;
    private List <float[][]> weights;
    private int totalLayers = 0 ;

    public NeuralNetwork()
{
	totalLayers = hiddenLayers + 2;
	weights = new List<float[][]>();
	neurons = new List<List<float>>();
	for(int i=0; i < totalLayers ; i++)
	{	float[][] layerWeights;
		List<float> layer = new List<float>();
		int sizeLayer = getSizeLayer(i);
		if(i != 1+hiddenLayers)
		{	
			layerWeights = new float[sizeLayer][];
			int nextSizeLayer = getSizeLayer(i+1);
			for(int j=0; j < sizeLayer; j++)
			{	
                layerWeights[j] = new float[nextSizeLayer];
				for(int k=0; k < nextSizeLayer;k++)
				{
					layerWeights[j][k] = genRandomValue();
				}
			}
			weights.Add(layerWeights);
		}
		for(int j=0;j<sizeLayer;j++)
		{
			layer.Add(0);
		}
		neurons.Add(layer);
	}
}

public NeuralNetwork(DNA dna)
{
	List<float[][]>weightsDNA = dna.getDNA();
	totalLayers = hiddenLayers + 2;
	weights = new List<float[][]>();
	neurons = new List<List<float>>();
	for(int i=0; i < 2+hiddenLayers; i++)
	{	float[][] layerWeights;
		List<float> layer = new List<float>();
		int sizeLayer = getSizeLayer(i);
		if(i !=1+hiddenLayers)
		{	float[][] dnaWeights = weightsDNA[i];
			layerWeights = new float[sizeLayer][];
			int nextSizeLayer = getSizeLayer(i+1);
			for(int j=0; j < sizeLayer; j++)
			{	layerWeights[j] = new float[nextSizeLayer];
				for(int k=0; k < nextSizeLayer;k++)
				{
					layerWeights[j][k] = dnaWeights[j][k];
				}
			}
			weights.Add(layerWeights);
		}
		for(int j=0;j<sizeLayer;j++)
		{
			layer.Add(0);
		}
		neurons.Add(layer);
	}
}

public void feedForward(float[]inputs)
{
	List<float>inputLayer = neurons[0];
	for(int i = 0 ; i < inputLayer.Count ; i++)
	{
		inputLayer[i] = inputs [i] ;
	}
	for (int layer = 0 ; layer <neurons.Count-1 ; layer++)
	{
		float[][] weightLayer = weights[layer];
		int nextLayer = layer+1;
		List<float>neuronsLayer = neurons[layer];
		list<float>neuronsNextLayer = neurons[layer+1];
		for (int i = 0 ; i < neuronsNextLayer.Count ; i++)
		{
			string s = "" ;
			float sum = 0 ;
			for(int j = 0 ; j < neuronsLayer.Count ; j++)
			{
				sum+ = weightLayer[j][i] * neuronsLayer [j];
				s+ = "[" + weightLayer[j][i] + " : " + neuronsLayer[j] + "]" + layer ;
			}
			neuronsNextLayer[i] = sigmoid (sum);
		}
	}
}

public int getSizeLayer(int i)
{
    int sizeLayer=0;
    if(i==0)
    {
        sizeLayer=inputs;
    }
    else if(i==hiddenLayers+1)
    {
        sizeLayer=outputs;
    }
    else
    {
        sizeLayer = size_hidden_layers;
    }
    return sizeLayer;

}

public List<float> getOutputs()
{
    return neurons[neurons.Count-1];
}

public float sigmoid(float x)
{
    return 1/ (float)(1+ Mathf.Pow(EULER_NUMBER,-x));
}

public float genRandomValue()
{
    return Random.Range(-maxInitialValue, maxInitialValue);
}

public List<List<float>> getNeurons()
{
    return neurons;
}

public List<float[][]> getWeights()
{
    return weights;
}


}
