using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessTest
{
    public class Lights
    {
        public enum State
        {
            On,
            Off,
            Dimmed
        }
        public enum Trigger
        {
            TurnOn,
            TurnOff,
            Dim
        }

        StateMachine<State, Trigger> _stateMachine;
        public State CurrentState => _stateMachine.State;

        public Lights()
        {
            _stateMachine = new StateMachine<State, Trigger>(State.Off);

            _stateMachine.Configure(State.Off)
                .Permit(Trigger.TurnOn, State.On)
                .Permit(Trigger.Dim, State.Dimmed)
                .OnEntry(TurnLightsOff)
                .OnActivate(() => Console.WriteLine("Lights are off, eh?"));

            _stateMachine.Configure(State.On)
                .Permit(Trigger.TurnOff, State.Off)
                .Permit(Trigger.Dim, State.Dimmed)
                .OnEntry(TurnLightsOn);

            _stateMachine.Configure(State.Dimmed)
                .Permit(Trigger.TurnOn, State.On)
                .Permit(Trigger.TurnOff, State.Off)
                .OnEntry(DimLights);

        }

        private void DimLights()
        {
            Console.WriteLine("Lights are Dimmed");
        }

        public bool Transition(Trigger trigger)
        {
            if (!_stateMachine.CanFire(trigger))
            {
                return false;
            }

            _stateMachine.Fire(trigger);

            return true;
        }

        private void TurnLightsOff()
        {
            Console.WriteLine("Lights are Off");
        }

        private void TurnLightsOn()
        {
            Console.WriteLine("Lights are On");
        }
    }
}
