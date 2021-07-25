using UnityEngine;

namespace Helab.Simply
{
    [RequireComponent(typeof(Renderer))]
    public class SetRendererColor : MonoBehaviour
    {
        private Renderer _renderer;

        public static void ChangeColorIfAttachedComponent(Transform targetTransform, Color color)
        {
            var component = targetTransform.GetComponent<SetRendererColor>();
            if (component == null)
            {
                return;
            }
            
            component.SetColor(color);
        }

        public void RefreshWithRandom()
        {
            SetColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        }

        public void SetColor(Color color)
        {
            var r = GetRenderer();
            if (r == null)
            {
                return;
            }
            
            r.material.color = color;
        }

        private Renderer GetRenderer()
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
            }

            return _renderer;
        }
    }
}
