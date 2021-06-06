using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityEditor.Timeline
{
    static class PickerUtils
    {
        public static List<object> pickedElements { get; private set; }

        public static void DoPick(WindowState state, Vector2 mousePosition)
        {
            if (state.GetWindow().sequenceHeaderRect.Contains(mousePosition))
            {
                pickedElements = state.headerSpacePartitioner.GetItemsAtPosition<object>(mousePosition).ToList();
            }
            else if (state.GetWindow().sequenceContentRect.Contains(mousePosition))
            {
                pickedElements = state.spacePartitioner.GetItemsAtPosition<object>(mousePosition).ToList();
            }
            else
            {
                if (pickedElements != null)
                    pickedElements.Clear();
                else
                    pickedElements = new List<object>();
            }
        }

        public static T PickedLayerableOfType<T>() where T : class, ILayerable
        {
            return pickedElements.OfType<ILayerable>().OrderBy(x => x.zOrder).LastOrDefault() as T;
        }

        public static IEnumerable<T> PickedAllElementsOfType<T>() where T : class, ILayerable
        {
            return pickedElements.OfType<T>().OrderBy(x => x.zOrder);
        }

        public static T FirstPickedElementOfType<T>() where T : class, IBounds
        {
            return pickedElements.FirstOrDefault(e => e is T) as T;
        }
    }
}
