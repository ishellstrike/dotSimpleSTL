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

layout (local_size_x = 1, local_size_y = 256, local_size_z = 1) in;
void main(){
	uint i = gl_GlobalInvocationID.x*3;
	float a = p[i].a * p[i].a * p[i].a * p[i].a;
	p[i].a = a;
	p[i+1].a = a;
	p[i+2].a = a;
}