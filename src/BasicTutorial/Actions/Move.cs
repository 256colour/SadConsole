﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Entities;

namespace SadConsole.Actions
{
    class Move : ActionBase
    {

        public static Move MoveBy(GameObjects.GameObjectBase source, Point change, Maps.SimpleMap map)
        {
            return new Move() { Source = source, PositionChange = change, Map = map };
        }

        public Maps.SimpleMap Map;
        public GameObjects.GameObjectBase Source;
        public Point PositionChange;
        public Point TargetPosition;

        public override void Run(TimeSpan timeElapsed)
        {
            TargetPosition = Source.Position + PositionChange;

            if (TargetPosition == Source.Position)
                return;

            if (Map.IsTileWalkable(TargetPosition.X, TargetPosition.Y))
            {
                var ent = Map.GetGameObject(TargetPosition);

                if (ent == null)
                {
                    Source.MoveBy(PositionChange, Map);

                    if (Source == Map.ControlledGameObject)
                    {
                        if (PositionChange == Directions.West)
                            BasicTutorial.GameState.Dungeon.Messages.Print("You move west.", BasicTutorial.MessageConsole.MessageTypes.Status);
                        else if (PositionChange == Directions.East)
                            BasicTutorial.GameState.Dungeon.Messages.Print("You move east.", BasicTutorial.MessageConsole.MessageTypes.Status);
                        else if (PositionChange == Directions.North)
                            BasicTutorial.GameState.Dungeon.Messages.Print("You move north.", BasicTutorial.MessageConsole.MessageTypes.Status);
                        else if (PositionChange == Directions.South)
                            BasicTutorial.GameState.Dungeon.Messages.Print("You move south.", BasicTutorial.MessageConsole.MessageTypes.Status);

                    }
                }
                else
                {
                    //BumpEntity bump = new BumpEntity(Source, ent);
                    //Program.AdventureScreen.RunCommand(bump);
                }
            }
            else
            {
                //BumpTile bump = new BumpTile(Source, Program.AdventureScreen.Map[TargetPosition]);
                //Program.AdventureScreen.RunCommand(bump);
            }

            Finish(ActionResult.Success);
        }
    }

}