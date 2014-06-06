#extension GL_ARB_compute_shader : enable
#extension GL_ARB_shader_storage_buffer_object : enable
#define M_PI 3.1415926535897932384626433832795

//floats for no alignment
struct particle{
	float vx,vy,vz,ux,uy,nx,ny,nz,a,s;
};

layout(std140) buffer particles{
	particle p[];
};

uniform float Current;

float ElementShadow(vec3 v, float rSquared, vec3 receiverNormal, vec3 emitterNormal, float emitterArea) {
  // we assume that emitterArea has already been divided by PI
  return (1 - 1.0 / sqrt(emitterArea/rSquared + 1)) * clamp(dot(emitterNormal, v), 0, 1) * clamp(4 * dot(receiverNormal, v), 0, 1);
}

layout (local_size_x = 256, local_size_y = 1, local_size_z = 1) in;
void main(){
	uint i = gl_GlobalInvocationID.x*3;
	uint j = gl_GlobalInvocationID.y*3;
	
	particle v0 = p[i];
	particle vv0 = p[j];
	
	vec3 v = vec3(vv0.vx, vv0.vy, vv0.vz) - vec3(v0.vx, v0.vy, v0.vz);
	float d2 = dot(v, v) + 1e-16;
	
	v *= 1.0f / sqrt(d2);
	float value = ElementShadow(v, d2, vec3(v0.nx, v0.ny, v0.nz), vec3(vv0.nx, vv0.ny, vv0.nz), vv0.s);
	
	p[i].a -= value;
	p[i+1].a -= value;
	p[i+2].a -= value;
}