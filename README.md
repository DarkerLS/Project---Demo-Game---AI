# Project---Demo-Game---AI
Small Machine Learning Project in Unity. Scripts to Setup and run.


I wanted to learn Unity and start a little adventure on Indie Development, but i love technology in general and still have a big connection to my Physics dream, my life hasn't been great, not really that long ago i got my real first hobby, something i wouldn't mind doing all day long. And after exploring different mediums to tell a story, i finally decided that a small game would be the right way.

So with my small 3D modeling skills and my desire to go big, i imagined a perfect 3d world where i would tell the story of twin sister AI's.


For the project:


I split my tasks into 3 fases:

1 - Game Level

      In which i would create the game level and the different learning scenes; 

2 - Working Code

      Working c# scripts for character control and enemy AI; And working RL (Reinforcement Learning) and IL (Imitation Learning) scenes;
      
3 - Playable Test

      Remodeling assets and level look + online website for the presentation;
  
  
------------------------------------------------------------------------------------------------------------------------------------------------------------

So i went right into Unity and made a game scene without really researching anything, i created models and even created procedually generated terrain based on the Perlin Noise texture - following a few tutorials, changed the rendering method a couple times to make it compatible with my blender shading graphs and Substance Painter texture files, just to in the end not being able to use it as the animator wouldn't make transitions and everything felt unrealistic because i couldn't really make the model for my first AI float properly on the irregular terrain. So a platform it needed to be;

Here you install Python and create the conventional python virtual environment in the Unity project's folder;

in the command line and having python installed it is as easy as:


    python -m venv name
    
Activating the virtual environment as:
  
    name\Scripts\activate
    
*NOTE "name" above is used as a placeholder, it really could be any name*
*The virtual environment isn't needed but it is recommended as it isolates the packages from other environments and out of the main pc itself, so it's easier to diagnose compatibility errors later*

Install only 2 packages:

https://pytorch.org/


to get my Pytorch module installation:
  
  
    pip3 install torch torchvision torchaudio --extra-index-url https://download.pytorch.org/whl/cu113


and then to install MLAgents:

    pip istall mlagents
  
  
And that was easy so far;

Here you actually have to install the mlagents package in your Unity project editor under window and manage packages, at the time of the first tutorials of this, there were not as many versions as there are today, but i tried the newest one anyway;

Wrong choice;


Back in the command line you now should run:

    mlagents-learn --help
    
This will actually give back all extra commands you could use after "mlagents-learn", but it also works as a checking command, because if something isn't installed properly, it will give a Python traceback, which i got a couple of times;

After a while changing versions of everything, even modules inside the mlagents package, as this brings modules like tensorboard and numpy which have different versions on their own i finally got working versions between them:

    Python 3.7.6
    Unity Editor 2019.4.38f1
    Unity Editor MLAgents package version 1.6.0-preview
    
    
Had to redo the whole game scene again;

But then i couldn't adapt my movement and animation scripts to the Agent Class;


To explain this:

  MLAgents works by implementing a class that we can use for our class to derive from;
  So my movement script and animation script had to derive from the Agent Class and override some of their core functions for it to work:
  
    public override void CollectObservations(VectorSensor name)
    {}
    public override void OnActionReceived(ActionBuffer name)
    {}
    public override void Heuristic(in ActionBuffers nameOut)
    {}
    
For more information visit:

https://unity.com/products/machine-learning-agents

  There is an example of a moving robot moving using rigging bones (so pretty realistic if we humans had to learn to use our bones again to move our body) and for this i had to learn rigging in Unity, which is not the same as rigging in Blender so i gave up on the graphics and physics so there flew off the dream of a possible game AI for an RPG as an enemy;
  
  So basically i could give up anytime now as the main objective wasn't achievable anyway and later one other objective will not be achievable;
  
  For now i just continued and made everything from simple shapes, followed some basic tutorials and made one scene work; 
  
  For my second scene i wanted the simple cude to jump over a wall so in theory the only thing i had to add were a couple lines of code for the jump action, but as you see the three main functions you had to override are quite demanding, the first CollectObservations is where you would have to write ways for the Agent to see, the second, OnActionReceived is a list of actions the Agent could use to achieve the reward and then the last, Heuristic where you have to translate the actions to some way of input so that you can control the Agent using keyboard and mouse (or any other input device you listed, and here i could have explored the new input system and keybindings in Unity, but i went simple as this is already to complex for me), anyway;
  
  The first scene used ContinuousActions, so it knew that 0 was 0, so no movement and anything in between 0 and 1 was movement:
  
  
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(targetTransform.position);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * 5;
    }
    
    public override void Heuristic( in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[0] = Input.GetAxisRaw("Vertical");
    }
    
    
   In the first scene it get's information of it's location and the target's location, so even if it is randomized it would find it after some time;
   In the second scene it's reward was just always on the other side of the wall so it also wasn't hard for it to find it after the jump;
   
   But the challenge here was that a jump is a DiscreteAction instead of a ContinuousAction, but the Behaviour Parameters Script only allows for one type of action at a time, so i tried to transform a discrete action to a continuous action, this basically means i tried to convert a 0 or 1 action to a 0 and everthing in between until 1 action, integer to float. I couldn't do it. So the solution was to do it the other way around:
   
    public override void OnActionReceived(ActionBuffers acts)
    {
        int moveX = acts.DiscreteActions[0];
        int moveZ = acts.DiscreteActions[1];
        
        Vector3 addForce = new Vector3(0, 0, 0);

        switch (moveX)
        {
            case 0: addForce.x = 0f; break;
            case 1: addForce.x = -1f; break;
            case 2: addForce.x = +1f; break;
        }

        switch (moveZ)
        {
            case 0: addForce.z = 0f; break;
            case 1: addForce.z = -1f; break;
            case 2: addForce.z = +1f; break;
        }

        rigidA.velocity = addForce * moveSpeed + new Vector3(0, rigidA.velocity.y, 0);
    }
    
   
   It looks easy but i had a bad figuring this out;
   
   With this i finally got the Agent to move based on DiscreteActions and now a jumping action wasn't to difficult to do, in fact realizing this allows me to use any key as input to be honest. The problem is that smooth moving doesn't come with ints, and the free look around was now gone, i couldn't figure out how to rotate the view and the movement at the same time, so moveX 1 is always right but in a world space view, not your relative right.
   
   I will figure this out eventually, didn't do it for this project;
   
   Now one other thing the scenes had was that everything was pretty blocked out and measured, so for an AI it isn't to difficult to "download" it's surroundings as it's size was locked and always the same eventhough the reward position was randomized;
   
   So i had the plan to make it bigger and more random;
   

--------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
  The actual final product:
    
    GridSpawner.cs
  
  In a new scene, onto an empty object the GridSpawner Script is added, this script asks for an Array of GameObjects, which i called "floor";
  For this i only added 2 different ones, one where the floor is just floor, and another where the floor is cracked and takes points, as they would have equal chance of spawning i added 9 floors and 1 cracked floor, just to make more normal floors appear. In the script you have two other variables to define size of the grid i called them gridX and gridZ, gridOffset is important as it defines the spacing between points in the grid, so say your floor as a X size of 2.5 and a Z size of 2.5, the spacing would have to be 2.5 for it not to overlap floors, and lastly a gridO vector3 just to assign the starting position;
  
  This script will spawn a floor in the positive x and z axis.
  
    CLister.cs
    WallSpawner.cs
    
  The floor is stored as a prefab, so it doesn't have to be in the scene and i only have to change it once for it to change everywhere it is referenced, just to say that the prefab has 5 spawn points (which are just empty objects with a script in this case), so one for each end of the square and one in the center, the one in the center i called spawnPointC, hence CLister, but this one has the CLister script associated to it to make a list of C points in the grid. The other 4 have the WallSpawner Script associated to them to make a wall spawn or not.
  The CLister script sends the list to the GoalSpawner script, that's all it does;
  The WallSpawner script accepts one GameObject and calculates if it is spawned or not based on it's 1/8 % chance to spawn. This is really low but it will look more like a 1/4 spawn chance as in most places of the grid there are actually 2 spawnPoints (as the floorsquares end and begin immediately one after another);
  
    GoalSpawner.cs
   
  As mentioned exactly 5 lines before this script starts with a List of spawnPointsC and accepts a new prefab, the goal;
  This one basically has a timer to allow for the C points to spawn first to create the list, then it has two functions, one to go through the list and pick one spawn point C and make the goal spawn in that spot and another just to be referenced when the current goal is destroyed and a new one can be spawned, therefore the use of a boolean;
  As you can see, the CList references a GameObject with tag "Grid", so the GoalSpawner must be associated to that object, which in this case is just the first GameObject and the only active in the scene so far, the one with the GridSpawner script;
  
    ScoreIncreaser.cs
    ScoreDecreaser.cs
    
  These two check for collisions, the main players would be the tag = "AI" and tag = "P1", player1, so for this case no other colliders are needed;
  ScoreIncreaser script is only associated with the goal and it basically destroyes the goal and asks for the ScoreManager script to add a point and says to the GoalSpawner that the goal doesn't exist so it can spawn a new one;
  ScoreDecreaser script is associated to for example the floor crack object, and it checks for the same colliders, and it asks the ScoreManager script to take a point;
  
    ScoreManager.cs
    
  So the ScoreManager script is associated to the UI and accepts 2 text type variables to update on screen the score of P1 and AI, here are 4 functions, 2 for each, and one to take and one to add points;
  
  *NOTE this scoring system isn't according to the AddReward() function on the Agent script which i'll talk about later, but it was only as a testing method as the UI isn't fully ready now;*
  
  
  
  So i finally had a nice automatic labyrinth level generator;
  
  
  WOULD MY AGENT ACTUALLY LEARN IN IT AND BECOME A GOOD AI TO PLAY AGAINST?
  
  Nope; And i could not solve the issue translating the tensor datatypes into one model, not sure if the way the obeservations where done here are to blame or if it was just a way too complex and random environment to make patterns out of it;
  
    AgentBasicController.cs
    
  
  The first thing you'll notice opening the script is a ton of lines for Raycasts, i tried to make a function using mathematical equations to make the raycasts, but i it wasn't understanding how i could use Quaternions and Vector3 and make it happen, so i did the old typing it manually, twice for each ray as they didn't show up if they weren't drawned with Debug.DrawRAY, in between the creation lines for the Raycasts and the drawing them lines, there is an omitted part of code which i'll refer to later;
  The raycasts where created and supposed to be used as a way to sense the goal, to get it's location in a more realistic way as just having it at all times like in the first scene, for this rayMask and rayRange where created just to assign values more quickly to each of the raycast line, one storing the layer of activeness and the range; 
  The mask was important as the ray wouldn't go through other collisions otherwise, so in other words, i needed the ray to hit only the goal and give information of it alone, so it  was a good idea not to block it with the walls or even the other player, and this would be fair as the game would end up being a top down view game, where the player had the whole labyrinth in front of him, only because of the issue that i couldn't figure out how to make discrete actions follow local rotation, so to prevent going backwards without looking, i set the view of the game as a top to bottom and the keys do what you expect without loosing visibility yourself;
  The range is important as it can make it harder for the AI to detect the AI if it isn't in range and loose orientation;
  
  The only other variable i needed to make related to RayCasts is inRay as this is essentially the goal as a hit in one of the rays;
  
  You'll see other stored variables like Rigidbody and yThrust, relevant for the jumping action and movement in general;
  And a timer;
    
  Going down after the Raycasts, you have Initialize() and OnEpisodeBegin(), this is because i needed to get the RigidBody as soon as the game could to start movement, Initialize() is essentially a substitute for Awake() in regular Unity c# programming, and OnEpisodeBegin() the substitute for Start(), in theory the latest could be omitted but i haven't tested that, and it was meant to start the timer at first, but it works out if too, soo i was left in here just because it could have been needed later, but it wasn't;
  
  Then CollectObservations(), like before, a way for the AI to know it's position and the goal's position, 6 observations in total, as they both are Vector3 variables and return a value for x, for y, and for z, the observations from the raycast will only exist if inRay is not null;
  
  The OnActionReceived(), listing 4 possible Discrete Actions, index [0] moveX, index [1] moveZ, index [2] Jump(1), index [3] SensRay(1);
  
  Then we say there are 3 possibilities for moveX, the move right, move left and don't move, and 3 possibilities moveZ, the move up, move down, and don't move;
  
  index [2] calls for the Jump() function and is only an actions if 1, the same with index [3] SensRay();
  
  The Jump() function, checks if your localY position is less than 1, just as an example, and it's just a general way to check if you are grounded, in this case it still gives both the AI and the P1 the flexibility to jump even if they aren't really touching the floor, so they could double jump or triple jump or jump the needed amount of times to float in mid air, yThrust is the variable that will influence the force added in the Y axis for them to go higher.
  
  The SensRay() functions is essentially all the raycast creation and checks if goal is in range and returns inRay for the observations;
  
  Then you have Heuristic() which basically gives a real world input to the actions mentioned before, so that we can use the actions when we are in control; it is important to say that here it will check if input is pressed or not, so say if KeyCode Space is pressed the Jump == 1, as was required in the OnActionReceived() function;
  
  
  Then there is the actual reward system for the AI to learn:
  
   OnTriggerEnter(Collider other)
   {}
   
   sets reward as 5 if in contact with goal nd set's reward as negative 1 if hit by floor cracks or anything with the tag = "Rift";
   
   Then there is the timer that also sets negative points each time it runs out; and maybe i should have done this in a FixedUpdate() function as the regular Update is quite unregular;
   
   
--------------------------------------------------------------------------------------------------------------------------------------------------------------------


HOW THIS ALL WORKS?


   Remembering where i left you at the command line, inside the virtual environment:

    mlagents-learn --help
    
   To start learning, in your project you have to check that your agent has a Behaviour Parameters script and a Decision Requester script, both come with the MLAgents package and should be findable if you add component and start typing those names in the add component search bar;
   
   The first regulates the behaviour, and the second regulates the decision taking;
   
   So in the first you have to change the observation space to your observations amount and the you have a slider to say how many the agent may use to make it's decision;
   
   If vector action type continuous it's as easy as putting the amount of indexes[] in the OnActionReceived();
   If vector action type discrete then you do the same, indexes[] as amount off branches but then specify the amount of possibilities in each branch, so say example above moveX index[] has possibility 1 = right, -1 = left, and 0 = stationary, so the branch for moveX is size 3;
   
   Here in the Behavior Parameters Script you also have a section to load a model to improve that brain model;
   And a behavior type which is set to Default as standard and this basically means when in a learning environment the Agent/ AI will only take the configuration file policies to train itself, wether they are of type extrinsic GAIL or BC;
   
   You also have Heuristic behavior, which if you recall properly means it will be controlled by you, the user; And an inference type which is essentially disregarding the learning environment and acting as an Heuristic type, this happens if you load on default but for some reason python and pytorch can't connect to your Unity Editor and start in a learning environment, so it will automatically change to inference type behavior;
   
   
   You also have the possibility to change between CPU and GPU, as those lovelly CUDA and Tensor cores on an NVidia GPU accelerate machine learning dramatically, in this case it doesn't really matter as it is as basic as it can get;
   
   In the Decision Requester script, you are expected to set the amount of time it needs to wait for it to make a decision based on it's observations, just a slider;
   
   Now letting it learn is in the command line just running:
   
    mlagents-learn
    
   If it's your first time it will run fine, and again if all versions of the different modules and packages are compatible with each other and python, but that should be correct now;
   
   
   
    (RLenv) C:\Users\ISO WHDH\My project (11)>mlagents-learn --run-id=EXAMPLE

               ┐  ╖
           ╓╖╬│╡  ││╬╖╖
       ╓╖╬│││││┘  ╬│││││╬╖
    ╖╬│││││╬╜        ╙╬│││││╖╖                               ╗╗╗
    ╬╬╬╬╖││╦╖        ╖╬││╗╣╣╣╬      ╟╣╣╬    ╟╣╣╣             ╜╜╜  ╟╣╣
    ╬╬╬╬╬╬╬╬╖│╬╖╖╓╬╪│╓╣╣╣╣╣╣╣╬      ╟╣╣╬    ╟╣╣╣ ╒╣╣╖╗╣╣╣╗   ╣╣╣ ╣╣╣╣╣╣ ╟╣╣╖   ╣╣╣
    ╬╬╬╬┐  ╙╬╬╬╬│╓╣╣╣╝╜  ╫╣╣╣╬      ╟╣╣╬    ╟╣╣╣ ╟╣╣╣╙ ╙╣╣╣  ╣╣╣ ╙╟╣╣╜╙  ╫╣╣  ╟╣╣
    ╬╬╬╬┐     ╙╬╬╣╣      ╫╣╣╣╬      ╟╣╣╬    ╟╣╣╣ ╟╣╣╬   ╣╣╣  ╣╣╣  ╟╣╣     ╣╣╣┌╣╣╜
    ╬╬╬╜       ╬╬╣╣      ╙╝╣╣╬      ╙╣╣╣╗╖╓╗╣╣╣╜ ╟╣╣╬   ╣╣╣  ╣╣╣  ╟╣╣╦╓    ╣╣╣╣╣
    ╙   ╓╦╖    ╬╬╣╣   ╓╗╗╖            ╙╝╣╣╣╣╝╜   ╘╝╝╜   ╝╝╝  ╝╝╝   ╙╣╣╣    ╟╣╣╣
       ╩╬╬╬╬╬╬╦╦╬╬╣╣╗╣╣╣╣╣╣╣╝                                             ╫╣╣╣╣
          ╙╬╬╬╬╬╬╬╣╣╣╣╣╣╝╜
              ╙╬╬╬╣╣╣╜
                ╙

    Version information:
      ml-agents: 0.29.0,
      ml-agents-envs: 0.29.0,
      Communicator API: 1.5.0,
      PyTorch: 1.11.0+cu113
    [INFO] Listening on port 5004. Start training by pressing the Play button in the Unity Editor.





>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>PLAY BUTTON IN UNITY EDITOR TO START TRAINNING<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<




    [INFO] Connected to Unity environment with package version 1.6.0-preview and communication version 1.2.0
    [INFO] Connected new brain: AgentBasic?team=0
    [WARNING] Behavior name AgentBasic does not match any behaviors specified in the trainer configuration file. A default configuration will be used.
    [INFO] Hyperparameters for behavior name AgentBasic:
         trainer_type:   ppo
        hyperparameters:
          batch_size:   1024
          buffer_size:  10240
          learning_rate:        0.0003
          beta: 0.005
          epsilon:      0.2
          lambd:        0.95
          num_epoch:    3
          learning_rate_schedule:       linear
          beta_schedule:        linear
          epsilon_schedule:     linear
        network_settings:
          normalize:    False
          hidden_units: 128
          num_layers:   2
          vis_encode_type:      simple
          memory:       None
          goal_conditioning_type:       hyper
          deterministic:        False
        reward_signals:
          extrinsic:
            gamma:      0.99
            strength:   1.0
            network_settings:
              normalize:        False
              hidden_units:     128
              num_layers:       2
              vis_encode_type:  simple
              memory:   None
              goal_conditioning_type:   hyper
              deterministic:    False
        init_path:      None
        keep_checkpoints:       5
        checkpoint_interval:    500000
        max_steps:      500000
        time_horizon:   64
        summary_freq:   50000
        threaded:       False
        self_play:      None
        behavioral_cloning:     None
    c:\users\iso whdh\my project (11)\rlenv\lib\site-packages\mlagents\trainers\torch\networks.py:91: UserWarning: Creating a tensor from a list of numpy.ndarrays is extremely slow. Please consider converting the list to a single numpy.ndarray with numpy.array() before converting to a tensor. (Triggered internally at  C:\actions-runner\_work\pytorch\pytorch\builder\windows\pytorch\torch\csrc\utils\tensor_new.cpp:210.)
      enc.update_normalization(torch.as_tensor(vec_input))
   
  
  
  It starts flawlessly (after a lot of pain figuring everything out);
  
  And you'll see it just going around as if it is lost; 
  
  Talking a little bit about what showed up on the command line after starting; the configuration file:
  
      [INFO] Hyperparameters for behavior name AgentBasic
  
  If there isn't one it will use default hyperparameters, but this is the file that regulates the policies of the behavior and allows you to change from Reinforcement Learning to Imitation Learning. To select a specific one use:
  
  
    mlagents-learn configpath/filename.yml
    
   And now you might get an error as it is your second time running this, and you cannot override previous runs, you could start from a previous one and continue from there, but for a new run use:
   
    mlagents-learn --run-id=nameofnewrun
    
   or
   
    mlagents-learn configpath/filename.yml --run-id=nameattempt3
    
    
   I don't understand most parameters and you could a lot more that aren't in the standard file, from the ones i now and played around with:
   
   batch_size: basically the amount of observations used at once to calculate patterns, needs to be a result of 2 to the power of X, binary stuff;
   
   num_epoch: is the amount of cycles to go through the same batch;
   
   then in the reward_signals:
      you have extrinsic - related to behavior type, and here you also can have GAIL which i show as an example in my yml file; Gail needs a demo for ImitationLearning
      
   these two fall under reward_signals and have a strenght parameter that says how much effect it will have on the learning,
   i have not used BC behavior clonning, but this is outside reward_signals and bases learning solely on the demo;
   
   checkpoint_interval: saves a brainmodel for each amount of steps set here;
   max_steps: if you want to run the learning session for the whole night make this number as big as possible;
   
   
   
   
   Okay now to get a demo file, In you Unity Editor, on your agent add a new component called Demonstration Recorder Script
   set it as active
   check Record box
   set steps to record
   set demofile name
   set demo path
   
   then play on heuristic;
   
   
   
   I am going to be honest here, i used this but i had errors trying to configure the yml file with it sometimes and i tweaked the other parameters and sometimes did work, but i haven't seen much improvement in learning in my case; I think i might be because it doesn't find a pattern in my actions, as turning on the raycasts and going to the goal doesn't really translate as i went to the goal because the raycast sensed it;
   
   
   Back in the command line:
   
    c:\users\iso whdh\my project (11)\rlenv\lib\site-packages\mlagents\trainers\torch\utils.py:320: UserWarning: The use of `x.T` on tensors of dimension other than 2 to reverse their shape is deprecated and it will throw an error in a future release. Consider `x.mT` to transpose batches of matricesor `x.permute(*torch.arange(x.ndim - 1, -1, -1))` to reverse the dimensions of a tensor. (Triggered internally at  C:\actions-runner\_work\pytorch\pytorch\builder\windows\pytorch\aten\src\ATen\native\TensorShape.cpp:2318.)
    return (tensor.T * masks).sum() / torch.clamp(
    [INFO] AgentBasic. Step: 50000. Time Elapsed: 442.998 s. Mean Reward: -0.267. Std of Reward: 0.744. Training.
    [INFO] AgentBasic. Step: 100000. Time Elapsed: 890.541 s. Mean Reward: -0.332. Std of Reward: 0.471. Training.
    [INFO] AgentBasic. Step: 150000. Time Elapsed: 1361.186 s. Mean Reward: -0.332. Std of Reward: 0.471. Training.
   
   
   Just as an example after 1 361 seconds, my scene made 150 000 steps and basically improved nothing, looking at the Mean Reward and the Std of Reward;
   
   The mean reward should improve as the agent get's more points, but at the moment the only thing he knows is that he loses points hence the negative value, it might have had luck on the start and picked up one reward as it is different, the Std of reward is better the lower it is as it means lack of consistency, in my books, so for a while we will see that it will stay around the 0.471 value as the only thing regulating points is the timer, as the Agent won't really be fast at getting points in these early steps;
   
   8 hours later: 
   
    [INFO] AgentBasic. Step: 3960000. Time Elapsed: 33546.376 s. Mean Reward: -0.340. Std of Reward: 0.474. Training.
    [INFO] AgentBasic. Step: 3970000. Time Elapsed: 33631.258 s. Mean Reward: -0.320. Std of Reward: 0.466. Training.
    [INFO] AgentBasic. Step: 3980000. Time Elapsed: 33718.417 s. Mean Reward: -0.340. Std of Reward: 0.474. Training.
    [INFO] AgentBasic. Step: 3990000. Time Elapsed: 33806.105 s. Mean Reward: -0.340. Std of Reward: 0.474. Training.
    [INFO] AgentBasic. Step: 4000000. Time Elapsed: 33895.318 s. Mean Reward: -0.320. Std of Reward: 0.466. Training.
    [INFO] Exported results\RLC59\AgentBasic\AgentBasic-3999974.onnx


  It isn't the first onnx file we got, but just to show how long random based learning may take, the values haven't change at all
  
  But now we have a brainmodel that we can import into unity as an asset load into the behavior parameters script and use as starting point for new learning and/or for our finall backed game;
  
  
  That's not the end, as in this specific scene that wasn't possible, in the other scene i could do that and i did and brainmodels are good; Here i get an error Concat_81 on the tensor creation logic, that means pytorch can't assemble the brain model correctly because somewhere in it's calculation it cannot join 2 tensor datatypes as one and proceed; I don't why this happens, but i lost faith at this point, it might all be because it the scene is as random as it can be and there aren't really any patterns, still a possible game for multiplayer P1 vs P2, but as it stands now, i can train AI but not really in complex scenes;
  
  I mentioned that there would be another objective not achievable from the start, and that is exactly that, the model would be backed into the game if i would make is as an executable and not only inside the editor, so my progressive Imitation Learning in which i wanted to use any player's session in game to get demo files for imitation learning isn't possible;
  

That's what the adventure was;

But then my heart had to go sentimental and use the cube's struggles as an example to why we all struggle, because we might be really close to our goal, and even sensing it, but if noone tells us that it is or where we have to go or what we have to do, we simply won't get there, because we might be seeing walls where there are none and we might be connected to something we thing is not a wall but might be one; And also the fact that it isn't about the reward, but the consistency of getting it too, i can learn to pass an exam or i can learn to be good at it for life, and AI has to be consistent so why we not, i really prefer to learn than actually just having a good score, and i feel like after a semester i haven't learned anything; 


But there is always hope;

Go back to the omitted lines of code between te raycasts, set them as readable and executable (so remove the // before each) and see the cube succeed and be the unbeatable AI the game deserves;
