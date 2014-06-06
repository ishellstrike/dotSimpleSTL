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

layout (local_size_x = 256, local_size_y = 1, local_size_z = 1) in;
void main(){

	uint i = gl_GlobalInvocationID.x*3;
	vec3 A = vec3(p[i].vx, p[i].vy, p[i].vz);
    vec3 B = vec3(p[i+1].vx, p[i+1].vy, p[i+1].vz);
	vec3 C = vec3(p[i+2].vx, p[i+2].vy, p[i].vz);
	
	float a = length(A - B);
    float b = length(B - C);
    float c = length(A - C);
    float s = (a + b + c) / 2.0f;
    float sq = sqrt(s * (s - a) * (s - b) * (s - c)) / M_PI;
	
	//set triangle square / M_PI
	p[i].s = p[i+1].s = p[i+2].s = sq / M_PI;
	//also zeroing ao
	p[i].a = p[i+1].a = p[i+2].a = 1;
}