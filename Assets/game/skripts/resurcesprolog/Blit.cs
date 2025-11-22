using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlitFeature : ScriptableRendererFeature
{
    [System.Serializable]
    public class BlitSettings
    {
        public Material material;
        public int passIndex = 0;
        public RenderPassEvent passEvent = RenderPassEvent.AfterRendering;
    }

    class BlitPass : ScriptableRenderPass
    {
        private Material material;
        private int passIndex;
        private RTHandle cameraColorTarget;

        public BlitPass(Material material, int passIndex, RenderPassEvent evt)
        {
            this.material = material;
            this.passIndex = passIndex;
            this.renderPassEvent = evt;
        }

        public void SetTarget(RTHandle colorTarget)
        {
            cameraColorTarget = colorTarget;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null)
                return;

            CommandBuffer cmd = CommandBufferPool.Get("Custom Blit");

            var source = cameraColorTarget;
            var dest = renderingData.cameraData.renderer.cameraColorTargetHandle;

            Blitter.BlitCameraTexture(cmd, source, dest, material, passIndex);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    public BlitSettings settings = new BlitSettings();
    private BlitPass pass;

    public override void Create()
    {
        pass = new BlitPass(settings.material, settings.passIndex, settings.passEvent);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.material == null) return;

        pass.SetTarget(renderer.cameraColorTargetHandle);
        renderer.EnqueuePass(pass);
    }
}
