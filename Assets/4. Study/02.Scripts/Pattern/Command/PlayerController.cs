using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand attackCommand, jumpCommand, skillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> excuteCommands = new Stack<ICommand>();

        private void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "FireBall");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                commandQueue.Enqueue(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (excuteCommands.Count > 0)
                {
                    ICommand lastCommand = excuteCommands.Pop();
                    Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");
                    
                    lastCommand.Cancel();
                }
                else
                {
                    Debug.Log("되돌릴 명령이 없습니다.");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 실행");
                while (commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                }
            }
        }
    }
}
