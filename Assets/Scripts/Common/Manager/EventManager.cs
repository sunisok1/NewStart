using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common.Manager
{
    public class EventManager : ManagerBase
    {
        private readonly Dictionary<EventType, EventHandler<EventArgs>> EventHandlers = new();

        // Method to subscribe to an event
        public void Subscribe(EventType eventType, EventHandler<EventArgs> handler)
        {
            if (!EventHandlers.ContainsKey(eventType))
            {
                EventHandlers[eventType] = null; // Initialize the event handler if it doesn't exist
            }

            EventHandlers[eventType] += handler;
        }

        // Method to unsubscribe from an event
        public void Unsubscribe(EventType eventType, EventHandler<EventArgs> handler)
        {
            if (EventHandlers.ContainsKey(eventType))
            {
                EventHandlers[eventType] -= handler;
            }
        }

        // Example method to invoke an event
        public void InvokeEvent(EventType eventType, object sender, EventArgs args)
        {
            if (EventHandlers.ContainsKey(eventType) && EventHandlers[eventType] != null)
            {
                EventHandlers[eventType]?.Invoke(sender, args);
            }
        }
    }
}
